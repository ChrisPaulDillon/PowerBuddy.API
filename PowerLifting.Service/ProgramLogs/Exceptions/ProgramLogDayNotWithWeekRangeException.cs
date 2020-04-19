using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogDayNotWithWeekRangeException : Exception
    {
        public ProgramLogDayNotWithWeekRangeException() : base("The Program Log Day Date is not within the given Program Week Date Range")
        {
        }
    }
}
