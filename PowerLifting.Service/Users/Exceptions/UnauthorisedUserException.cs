using System;
namespace PowerLifting.Service.Users.Exceptions
{
    public class UnauthorisedUserException : Exception
    {
        public UnauthorisedUserException(string message) : base(message)
        {
        }
    }
}
