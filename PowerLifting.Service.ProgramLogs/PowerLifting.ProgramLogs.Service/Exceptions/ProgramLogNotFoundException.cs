using System;

namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogNotFoundException : Exception
    {
        public ProgramLogNotFoundException() : base("ProgramLog Not Found")
        {
        }
    }
}