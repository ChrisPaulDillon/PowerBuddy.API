using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogWeekNotFoundException : Exception
    {
        public ProgramLogWeekNotFoundException() : base("ProgramLogWeek Not Found")
        {
        }
    }
}
