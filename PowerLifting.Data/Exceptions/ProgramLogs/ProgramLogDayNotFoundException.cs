using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogDayNotFoundException : Exception
    {
        public ProgramLogDayNotFoundException() : base("ProgramLogDay Not Found")
        {
        }
    }
}
