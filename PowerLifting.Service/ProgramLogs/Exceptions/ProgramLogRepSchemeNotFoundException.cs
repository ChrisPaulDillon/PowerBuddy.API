using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogRepSchemeNotFoundException : Exception
    {
        public ProgramLogRepSchemeNotFoundException() : base("ProgramLogRepScheme Not Found")
        {
        }
    }
}
