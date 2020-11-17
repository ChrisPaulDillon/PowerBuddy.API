using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User could not be found") { }
    }
}