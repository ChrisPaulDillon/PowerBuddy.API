using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using PowerBuddy.FileHandlerService.Exceptions;
using PowerBuddy.FileHandlerService.Utils;

namespace PowerBuddy.FileHandlerService.Services
{
    public class ImageFileHandlerService : FileHandlerService
    {
        protected override void ValidateFileExtension(IFormFile file)
        {
            if (!FileHelper.CheckFileIsImage(file))
            {
                throw new BadFileException("File is not an image");
            }
        }

        protected override void ValidateFileSize(IFormFile file)
        {
            if (FileHelper.CalculateFileSizeInMB(file.Length) > 10)
            {
                throw new BadFileException("File must be less than 10Mb");
            }
        }

        protected override string FormatFileName(IFormFile file)
        {
            if (file.FileName.Length < 1)
            {
                throw new BadFileException("File cannot have no name");
            }

            var extension = Path.GetExtension(file.FileName);

            var id = Guid.NewGuid().ToString();
            id = id.Replace("-", "");
            return $"{id.Substring(0, 20 - extension.Length)}{extension}";
        }
    }
}
