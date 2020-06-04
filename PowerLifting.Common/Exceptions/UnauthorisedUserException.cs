using System;
namespace PowerLifting.Common.Exceptions
{
    public class UnauthorisedUserException : Exception
    {
        public UnauthorisedUserException(string message) : base(message)
        {
        }
    }
}
