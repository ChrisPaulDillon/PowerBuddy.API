using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogAlreadyExistsException : Exception
    {
        public ProgramLogAlreadyExistsException() : base("The ProgramLog with this ID already exists")
        {
        }
    }
}
