using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogAlreadyExistsException : Exception
    {
        public ProgramLogAlreadyExistsException() : base("The ProgramLog with this ID already exists")
        {
        }
    }
}
