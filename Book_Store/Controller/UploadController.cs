﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.Interface;
using Model;
using Database.Entity.System;

namespace Book_Store.Controller
{

    public class UploadController : BaseController
    {
        private readonly ILogger<UploadController> _logger;
        private readonly AppConfig _appConfig;
        private readonly IFileRepository _fileRepository;

        public UploadController(ILogger<UploadController> logger, IOptions<AppConfig> appConfig, IFileRepository fileRepository)
        {
            _logger = logger;
            _appConfig = appConfig.Value;
            _fileRepository = fileRepository;
        }
        [HttpGet("{guid}")]
        [HttpGet("{guid}/{version}")]
        public IActionResult GetFile(Guid guid, uint? version)
        {
            var fileInfo = _fileRepository.GetFileInfo(guid, version);

            string mimeType = fileInfo.Extension switch
            {
                ".bmp" => "image/bmp",
                ".jpeg" or ".jpg" => "image/jpeg",
                ".png" => "image/png",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream",
            };
            return File(_fileRepository.GetFile(guid, version), mimeType);


        }

        [HttpGet("info/{guid}/")]
        [HttpGet("info/{guid}/{version}")]
        public ActionResult<FileStore> GetFileInfo(Guid guid, uint? version)
            => Ok(_fileRepository.GetFileInfo(guid, version));

        [HttpPost]
        public ActionResult<Guid> FileUpload([FromForm] IFormFile sourceFile, [FromForm] Guid guid)
        {
            if (sourceFile.Length > this._appConfig.MaxAllowedFileSizeInBytes)
            {
                _logger.LogError("File is bigger than the maximum allowed!");
                return BadRequest($"File maximális megengedett mérete: {this._appConfig.MaxAllowedFileSizeInMB} MB");
            }

            var stream = sourceFile.OpenReadStream();

            try
            {
                return Ok(_fileRepository.UploadFile(stream, sourceFile.FileName, guid));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while trying to upload a file: {ex.Message}");
                return BadRequest("Hiba történt a file feltöltése közben!");
            }

        }
        [HttpDelete("{guid}/{latest}")]
        public ActionResult<bool> DeleteFile(Guid guid, bool latest)
            => Ok(_fileRepository.DeleteFile(guid, latest));
    }
}
