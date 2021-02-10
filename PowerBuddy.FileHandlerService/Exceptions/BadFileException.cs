using System;

namespace PowerBuddy.FileHandlerService.Exceptions
{
    public class BadFileException : Exception
    {
        public BadFileException(string message) : base(message)
        {
            
        }
    }
}
