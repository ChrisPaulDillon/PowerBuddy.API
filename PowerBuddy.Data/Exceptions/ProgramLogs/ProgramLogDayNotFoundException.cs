using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogDayNotFoundException : Exception
    {
        public ProgramLogDayNotFoundException() : base("ProgramLogDay Not Found")
        {
        }
    }
}
