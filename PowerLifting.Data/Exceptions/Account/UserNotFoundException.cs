using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User could not be found") { }
    }
}