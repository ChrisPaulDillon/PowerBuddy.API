using System;

namespace PowerLifting.Data.Exceptions.LiftingStats
{
    public class LiftingStatNotFoundException : Exception
    {
        public LiftingStatNotFoundException() : base("Lifting stat not found")
        {
        }
    }
}