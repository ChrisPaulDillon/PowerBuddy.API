using System;
namespace PowerLifting.Service.LiftingStats.Exceptions
{
    public class LiftingStatNotFoundException : Exception
    {
        public LiftingStatNotFoundException(string message) : base(message)
        {
        }
    }
}
