using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogRepSchemeNotFoundException : Exception
    {
        public ProgramLogRepSchemeNotFoundException() : base("ProgramLogRepScheme Not Found")
        {
        }
    }
}
