using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogWeekNotFoundException : Exception
    {
        public ProgramLogWeekNotFoundException() : base("ProgramLogWeek Not Found")
        {
        }
    }
}
