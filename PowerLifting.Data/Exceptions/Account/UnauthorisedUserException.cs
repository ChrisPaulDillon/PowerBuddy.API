using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class UnauthorisedUserException : Exception
    {
        public UnauthorisedUserException(string message) : base(message)
        {
        }
    }
}
