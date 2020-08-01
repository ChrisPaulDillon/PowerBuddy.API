using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogWeekNotFoundException : Exception
    {
        public ProgramLogWeekNotFoundException() : base("ProgramLogWeek Not Found")
        {
        }
    }
}
