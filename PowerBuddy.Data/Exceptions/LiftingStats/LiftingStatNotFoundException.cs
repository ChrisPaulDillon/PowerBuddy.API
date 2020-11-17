using System;

namespace PowerBuddy.Data.Exceptions.LiftingStats
{
    public class LiftingStatNotFoundException : Exception
    {
        public LiftingStatNotFoundException() : base("Lifting stat not found")
        {
        }
    }
}