using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogDayOnDateAlreadyActiveException : Exception
    {
        public ProgramLogDayOnDateAlreadyActiveException() : base("Program Log Day already active for this date")
        {
            
        }
    }
}
