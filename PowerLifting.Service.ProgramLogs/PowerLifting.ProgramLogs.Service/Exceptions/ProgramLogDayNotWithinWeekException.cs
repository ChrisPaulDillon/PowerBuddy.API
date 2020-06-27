using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogDayNotWithinWeekException : Exception
    {
        public ProgramLogDayNotWithinWeekException() : base("The Program Log Day Date is not within the given Program Week Date Range")
        {
        }
    }
}
