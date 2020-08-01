using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogAlreadyActiveException : Exception
    {
        public ProgramLogAlreadyActiveException() : base("Program log already active for this user!")
        {
        }
    }
}
