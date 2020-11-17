using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogDayOnDateAlreadyActiveException : Exception
    {
        public ProgramLogDayOnDateAlreadyActiveException() : base("Program Log Day already active for this date")
        {
            
        }
    }
}
