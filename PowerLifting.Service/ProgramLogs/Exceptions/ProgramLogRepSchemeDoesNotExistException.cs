using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogRepSchemeDoesNotExistException : Exception
    {
        public ProgramLogRepSchemeDoesNotExistException() : base("Program Log Rep Schemes does not exist")
        {
        }
    }
}
