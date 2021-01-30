using System;

namespace PowerBuddy.MediatR.Commands.Authentication.Exceptions
{
    public class RefreshTokenNotFoundException : Exception
    {
        public RefreshTokenNotFoundException(string message) : base(message)
        {
            
        }
    }
}
