using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogAlreadyExistsException : Exception
    {
        public ProgramLogAlreadyExistsException() : base("The ProgramLog with this ID already exists")
        {
        }
    }
}
