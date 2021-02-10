using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace PowerBuddy.FileHandlerService.Utils
{
    public static class FileHelper
    {
        private static readonly List<string> ImageExtensions = new List<string> {".JPG", ".JPEG", ".PNG"};

        public static bool CheckFileIsImage(IFormFile file)
        {
            return ImageExtensions.Contains(Path.GetExtension(file.FileName)?.ToUpperInvariant());
        }

        public static decimal CalculateFileSizeInMB(long fileSize)
        {
            // Calculates the value to KB
            decimal valueInKB = (fileSize / 1024);
            // Calculayes the value in MB
            decimal valueInMB = (valueInKB / 1024);
            // Returns the value represented in MB
            return valueInMB;
        }
    }
}
