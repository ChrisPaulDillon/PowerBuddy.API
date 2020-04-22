using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogAlreadyActiveException : Exception
    {
        public ProgramLogAlreadyActiveException() : base("Program log already active for this user!")
        {
        }
    }
}
