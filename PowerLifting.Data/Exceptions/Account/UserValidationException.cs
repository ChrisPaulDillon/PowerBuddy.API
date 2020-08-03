using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Exceptions.Account
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(message) { }

        public UserValidationException() : base("Invalid parameters supplied") { }
    }
}
