using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogNotFoundException : Exception
    {
        public ProgramLogNotFoundException() : base("ProgramLog Not Found")
        {
        }
    }
}