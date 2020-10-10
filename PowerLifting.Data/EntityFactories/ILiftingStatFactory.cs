using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.LiftingStats;

namespace PowerLifting.Data.EntityFactories
{
    public interface ILiftingStatFactory
    {
        public LiftingStat Create(int exerciseId, decimal weight, int repRange, DateTime lastUpdated, string userId);
    }
}
