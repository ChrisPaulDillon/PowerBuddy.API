using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.EntityFactories
{
    public interface ILiftingStatFactory
    {
        public LiftingStat Create(int exerciseId, decimal weight, int repRange, DateTime lastUpdated, string userId);
    }
}
