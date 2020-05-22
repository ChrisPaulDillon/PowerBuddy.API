using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogDayNotFoundException : Exception
    {
        public ProgramLogDayNotFoundException() : base("ProgramLogDay Not Found")
        {
        }
    }
}
