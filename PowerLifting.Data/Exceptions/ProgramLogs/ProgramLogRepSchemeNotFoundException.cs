using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogRepSchemeNotFoundException : Exception
    {
        public ProgramLogRepSchemeNotFoundException() : base("ProgramLogRepScheme Not Found")
        {
        }
    }
}
