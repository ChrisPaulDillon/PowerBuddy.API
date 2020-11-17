using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogDayNotWithinWeekException : Exception
    {
        public ProgramLogDayNotWithinWeekException() : base("The Program Log Day Date is not within the given Program Week Date Range")
        {
        }
    }
}
