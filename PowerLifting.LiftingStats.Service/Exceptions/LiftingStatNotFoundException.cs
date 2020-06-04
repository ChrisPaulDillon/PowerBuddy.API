using System;

namespace PowerLifting.LiftingStats.Service.Exceptions
{
    public class LiftingStatNotFoundException : Exception
    {
        public LiftingStatNotFoundException() : base("Lifting stat not found")
        {
        }
    }
}