using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using PowerBuddy.FileHandlerService.Models;

namespace PowerBuddy.FileHandlerService.Services
{
    public abstract class FileHandlerService
    {
        public byte[] ConvertFile(IFormFile file, out string fileName)
        {
            ValidateFileExtension(file);
            ValidateFileSize(file);
            fileName = FormatFileName(file);

            return ConvertFileToByteArray(file);
        }

        protected abstract void ValidateFileExtension(IFormFile file);

        protected abstract void ValidateFileSize(IFormFile file);

        protected abstract string FormatFileName(IFormFile file);

        protected virtual byte[] ConvertFileToByteArray(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
