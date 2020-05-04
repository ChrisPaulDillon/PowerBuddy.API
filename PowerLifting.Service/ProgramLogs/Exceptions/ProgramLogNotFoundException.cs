using System;

namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogNotFoundException : Exception
    {
        public ProgramLogNotFoundException() : base("The program log associated with the Id provided does not exist")
        {
        }
    }
}