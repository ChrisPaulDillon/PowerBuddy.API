using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class UserProfileNotPublicException : Exception
    {
        public UserProfileNotPublicException() : base("This users profile is not public")
        {
            
        }
    }
}
