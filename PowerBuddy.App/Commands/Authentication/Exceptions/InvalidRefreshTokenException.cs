using System;

namespace PowerBuddy.App.Commands.Authentication.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException(string message) : base(message)
        {

        }
    }
}
