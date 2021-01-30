using System;

namespace PowerBuddy.MediatR.Commands.Authentication.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException(string message) : base(message)
        {

        }
    }
}
