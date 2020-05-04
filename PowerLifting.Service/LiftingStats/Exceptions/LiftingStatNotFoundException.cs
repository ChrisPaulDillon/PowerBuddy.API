using System;

namespace PowerLifting.Service.LiftingStats.Exceptions
{
    public class LiftingStatNotFoundException : Exception
    {
        public LiftingStatNotFoundException() : base("Lifting stat not found")
        {
        }
    }
}