using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogAlreadyActiveException : Exception
    {
        public ProgramLogAlreadyActiveException() : base("Program log already active for this user!")
        {
        }
    }
}
