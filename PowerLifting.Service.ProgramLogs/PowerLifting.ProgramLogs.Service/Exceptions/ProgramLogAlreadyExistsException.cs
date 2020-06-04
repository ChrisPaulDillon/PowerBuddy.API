using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogAlreadyExistsException : Exception
    {
        public ProgramLogAlreadyExistsException() : base("The ProgramLog with this ID already exists")
        {
        }
    }
}
