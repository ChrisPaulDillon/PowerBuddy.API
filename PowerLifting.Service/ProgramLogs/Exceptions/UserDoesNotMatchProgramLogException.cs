using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class UserDoesNotMatchProgramLogException : Exception 
    {
        public UserDoesNotMatchProgramLogException(string message) : base(message)
        {
        }
    }
}
