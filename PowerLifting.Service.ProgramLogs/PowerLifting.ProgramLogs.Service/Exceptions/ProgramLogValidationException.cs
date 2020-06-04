using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogValidationException : Exception
    {
        public ProgramLogValidationException(string message) : base(message)
        {
        }
    }
}
