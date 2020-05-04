using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogDayDoesNotExistException : Exception
    {
        public ProgramLogDayDoesNotExistException() : base("Program Log Day does not exist")
        {
        }
    }
}
