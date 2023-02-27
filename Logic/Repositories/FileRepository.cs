﻿using AutoMapper;
using Database;
using Database.Entity.System;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Logic.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ILogger<FileRepository> _logger;
        private readonly AppConfig _appConfig;
        private readonly BookStoreContext _dbContext;
        private readonly DbSet<FileStore> _dbSet;
        private readonly IMapper _mapper;

        public readonly string storageBaseDir;

        public FileRepository(
            ILogger<FileRepository> logger,
           IOptions<AppConfig> appConfig,
            BookStoreContext dbContext,
            DbSet<FileStore> dbSet,
            IMapper mapper)
        {
            storageBaseDir =
                Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), appConfig.Value.FileStorePath
                );

            if (!Directory.Exists(storageBaseDir))
            {
                _logger.LogError($"File-storage directory does not exist: {storageBaseDir}");
            }

            _logger = logger;
            _appConfig = appConfig.Value;
            _dbContext = dbContext;
            _dbSet = dbSet;
            _mapper = mapper;
            this.storageBaseDir = storageBaseDir;
        }

        public Stream GetFile(Guid fileId, uint? version = null)
        {
            _logger.LogInformation($"Get file with the following id: {fileId}");

            FileStore fileEntity;

            if (version is null)
            {
                fileEntity = _dbSet.Where(file => file.Guid.Equals(fileId))
                    .OrderByDescending(file => file.Version).FirstOrDefault();

                if (fileEntity is null)
                {
                    _logger.LogError($"File can not be found in the database with the following id: {fileId}");
                    return null;
                }
            }
            else
            {
                fileEntity = _dbSet.FirstOrDefault(file => file.Guid.Equals(fileId) && file.Version == version);

                if (fileEntity is null)
                {
                    _logger.LogError($"File can not be found in the database with the following version: {version}");
                    return null;
                }
            }

            var fileLocation =
                Path.Combine(
                    storageBaseDir,
                    fileEntity.Guid.ToString() + "_" + fileEntity.Version + fileEntity.Extension
                    );

            if (!File.Exists(fileLocation))
            {
                _logger.LogError($"File not exists on the storage with the following id: {version}");
                return null;
            }

            return File.OpenRead(fileLocation);
        }

        public FileStore GetFileInfo(Guid fileId, uint? version = null)
        {
            _logger.LogInformation($"Get file info with the following id: {fileId}");

            FileStore fileEntity;

            if (version is null)
            {
                fileEntity = _dbSet.Where(file => file.Guid.Equals(fileId))
                    .OrderByDescending(file => file.Version).FirstOrDefault();

                if (fileEntity is null)
                {
                    _logger.LogError($"File can not be found in the database with the following id: {fileId}");
                    return null;
                }
            }
            else
            {
                fileEntity = _dbSet.FirstOrDefault(file => file.Guid.Equals(fileId) && file.Version == version);

                if (fileEntity is null)
                {
                    _logger.LogError($"File can not be found in the database with the following version: {version}");
                    return null;
                }
            }

            return fileEntity;
        }
        public Guid UploadFile(Stream stream, string fileName, Guid? fileId = null)
        {
            _logger.LogInformation($"File upload with the following id: {fileId ?? Guid.Empty}");

            var exists = fileId is not null && _dbSet.Any(file => file.Guid.Equals(fileId));

            if (!exists)
            {
                fileId = Guid.NewGuid();
            }

            using var shaManager = new SHA512Managed();

            var hashStream = new MemoryStream((int)stream.Length);
            stream.CopyTo(hashStream);
            hashStream.Position = 0;
            stream.Position = 0;

            var hash = shaManager.ComputeHash(hashStream);
            var hashAsHexString = BitConverter.ToString(hash).Replace("-", "");

            var fileEntity = new FileStore
            {
                Guid = (Guid)fileId,
                Name = Path.GetFileNameWithoutExtension(fileName),
                UploadedAt = DateTime.Now,
                Size = stream.Length,
                Version = 1,
                Extension = Path.GetExtension(fileName),
                SHA512Hash = hashAsHexString
            };

            if (exists)
            {
                var latestVersion = _dbSet.Where(file => file.Guid.Equals(fileId))
                    .OrderByDescending(file => file.Version).FirstOrDefault();

                fileEntity.Version = latestVersion.Version + 1;
            }

            // copy file to permament storage
            try
            {
                var fileLocation =
                    Path.Combine(
                        storageBaseDir,
                        fileEntity.Guid.ToString() + "_" + fileEntity.Version + fileEntity.Extension
                        );
                var fileStream = File.OpenWrite(fileLocation);
                stream.CopyTo(fileStream);
                fileStream.Close();

                // TODO hash
                //var alg = SHA512.Create();
                //fileEntity.SHA512Hash = 
            }
            catch (Exception ex)
            {
                _logger.LogError($"File could not be written to it's location: {ex.Message}");
                return Guid.Empty;
            }

            var addResult = _dbSet.Add(fileEntity);
            _dbContext.SaveChanges();

            return addResult.Entity.Guid;
        }
        public bool DeleteFile(Guid fileId, bool latest = true)
        {
            var filesToDelete = _dbSet.Where(file => file.Guid.Equals(fileId))
                .OrderByDescending(file => file.Version).ToList();

            if (!filesToDelete.Any())
            {
                _logger.LogError($"File and it's versions can not be found in the database with the following id: {fileId}");
                return false;
            }

            if (latest)
            {
                _logger.LogInformation($"Delete the latest file with the following id: {fileId}");

                _dbSet.Remove(filesToDelete[0]);

                var fileLocation =
                    Path.Combine(
                        storageBaseDir,
                        filesToDelete[0].Guid.ToString() + "_" + filesToDelete[0].Version + filesToDelete[0].Extension);

                try
                {
                    File.Delete(fileLocation);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"File can not be deleted from the location: {fileLocation}");
                    _logger.LogError($"Error message: {ex.Message}");
                    return false;
                }
            }
            else
            {
                _logger.LogInformation($"Delete file and it's versions with the following id: {fileId}");

                foreach (var file in filesToDelete)
                {
                    _dbSet.Remove(file);

                    var fileLocation =
                        Path.Combine(
                            storageBaseDir,
                            file.Guid.ToString() + "_" + file.Version + file.Extension);

                    try
                    {
                        File.Delete(fileLocation);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"File can not be deleted from the location: {fileLocation}");
                        _logger.LogError($"Error message: {ex.Message}");
                        return false;
                    }
                }
            }
            _dbContext.SaveChanges();

            return true;
        }
    }
}
