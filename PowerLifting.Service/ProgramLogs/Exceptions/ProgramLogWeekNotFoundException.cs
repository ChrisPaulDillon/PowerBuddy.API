using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogWeekNotFoundException : Exception
    {
        public ProgramLogWeekNotFoundException() : base("ProgramLogWeek Not Found")
        {
        }
    }
}
