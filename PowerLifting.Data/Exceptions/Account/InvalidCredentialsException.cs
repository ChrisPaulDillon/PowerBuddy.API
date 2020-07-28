using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password")
        {
        }
    }
}
