using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class EmailNotConfirmedException : Exception
    {
        public EmailNotConfirmedException()
        {
            
        }

        public EmailNotConfirmedException(string message) : base(message)
        {
            
        }
    }
}
