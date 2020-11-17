using System;

namespace PowerBuddy.Data.Exceptions.System
{
    public class QuoteNotFoundException : Exception
    {
        public QuoteNotFoundException() : base("Quote could not be found")
        {
        }
    }
}
