using System;
namespace PowerLifting.Systems.Service.Exceptions
{
    public class QuoteNotFoundException : Exception
    {
        public QuoteNotFoundException() : base("Quote could not be found")
        {
        }
    }
}
