using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class UnauthorisedUserException : Exception
    {
        public UnauthorisedUserException(string message) : base(message)
        {
        }

        public UnauthorisedUserException() : base("User does not have permission for this action")
        {
        }
    }
}
