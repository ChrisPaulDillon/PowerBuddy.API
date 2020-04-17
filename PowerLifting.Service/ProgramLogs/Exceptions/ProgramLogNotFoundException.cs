using System;

namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogNotFoundException : Exception
    {
        public ProgramLogNotFoundException(string message) : base(message)
        {
        }
    }
}