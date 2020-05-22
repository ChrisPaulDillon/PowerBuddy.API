using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogValidationException : Exception
    {
        public ProgramLogValidationException(string message) : base(message)
        {
        }
    }
}
