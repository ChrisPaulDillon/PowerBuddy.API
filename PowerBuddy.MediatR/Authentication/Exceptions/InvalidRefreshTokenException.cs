using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBuddy.MediatR.Authentication.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException(string message) : base(message)
        {

        }
    }
}
