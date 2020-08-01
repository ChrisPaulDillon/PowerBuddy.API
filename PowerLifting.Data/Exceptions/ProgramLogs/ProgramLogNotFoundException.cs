using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogNotFoundException : Exception
    {
        public ProgramLogNotFoundException() : base("ProgramLog Not Found")
        {
        }
    }
}