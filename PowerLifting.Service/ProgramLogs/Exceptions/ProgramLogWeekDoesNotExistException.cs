using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogWeekDoesNotExistException : Exception
    {
        public ProgramLogWeekDoesNotExistException() : base("Program Log Week does not exist")
        {
        }
    }
}
