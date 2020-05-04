using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogsDoNotExistException : Exception
    {
        public ProgramLogsDoNotExistException() : base("No program logs found!")
        {
        }
    }
}
