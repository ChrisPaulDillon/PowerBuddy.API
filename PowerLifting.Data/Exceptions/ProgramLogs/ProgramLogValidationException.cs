using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogValidationException : Exception
    {
        public ProgramLogValidationException(string message) : base(message)
        {
        }
    }
}
