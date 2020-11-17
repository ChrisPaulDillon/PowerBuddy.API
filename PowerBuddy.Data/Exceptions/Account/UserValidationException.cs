using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(message) { }

        public UserValidationException() : base("Invalid parameters supplied") { }
    }
}
