using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Exceptions.Account
{
    public class UserProfileNotPublicException : Exception
    {
        public UserProfileNotPublicException() : base("This users profile is not public")
        {
            
        }
    }
}
