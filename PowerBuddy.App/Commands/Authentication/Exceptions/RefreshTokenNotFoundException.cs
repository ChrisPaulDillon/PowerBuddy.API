using System;

namespace PowerBuddy.App.Commands.Authentication.Exceptions
{
    public class RefreshTokenNotFoundException : Exception
    {
        public RefreshTokenNotFoundException(string message) : base(message)
        {
            
        }
    }
}
