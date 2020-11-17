using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password")
        {
        }
    }
}
