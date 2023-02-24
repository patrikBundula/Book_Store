using AutoMapper;
using Database;
using Database.Entity.System;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Logic.Repositories
{
    //    public class FileRepository : IFileRepository
    //    {
    //        private readonly ILogger<FileRepository> _logger;
    //        private readonly AppConfig _appConfig;
    //        private readonly BookStoreContext _dbContext;
    //        private readonly DbSet<FileStore> _dbSet;
    //        private readonly IMapper _mapper;

    //        public readonly string storageBaseDir;

    //        public FileRepository(Microsoft.Build.Framework.ILogger<FileRepository> logger, AppConfig appConfig, BookStoreContext dbContext, DbSet<FileStore> dbSet, IMapper mapper, string storageBaseDir)
    //        {
    //            _logger = logger;
    //            _appConfig = appConfig;
    //            _dbContext = dbContext;
    //            _dbSet = dbSet;
    //            _mapper = mapper;
    //            this.storageBaseDir = storageBaseDir;
    //        }

    //        public Guid UploadFile(Stream stream, string fileName, Guid? fielId = null)
    //        {

    //        }
    //}
}
