using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogDayNotFoundException : Exception
    {
        public ProgramLogDayNotFoundException() : base("ProgramLogDay Not Found")
        {
        }
    }
}
