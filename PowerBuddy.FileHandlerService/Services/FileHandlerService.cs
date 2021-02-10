using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using PowerBuddy.FileHandlerService.Models;

namespace PowerBuddy.FileHandlerService.Services
{
    public abstract class FileHandlerService
    {
        public byte[] ConvertFile(FormFile file, out string fileName)
        {
            ValidateFileExtension(file);
            ValidateFileSize(file);
            fileName = FormatFileName(file);

            return ConvertFileToByteArray(file);
        }

        protected abstract void ValidateFileExtension(FormFile file);

        protected abstract void ValidateFileSize(FormFile file);

        protected abstract string FormatFileName(FormFile file);

        protected virtual byte[] ConvertFileToByteArray(FormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
