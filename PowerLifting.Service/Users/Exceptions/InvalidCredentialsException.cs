using System;
namespace PowerLifting.Service.Users.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password")
        {
        }
    }
}
