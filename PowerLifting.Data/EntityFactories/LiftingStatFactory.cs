using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.LiftingStats;

namespace PowerLifting.Data.EntityFactories
{
    public class LiftingStatFactory : ILiftingStatFactory
    {
        public LiftingStat Create(int exerciseId, decimal weight, int repRange, DateTime lastUpdated, string userId)
        {
            return new LiftingStat()
            {
                ExerciseId = exerciseId,
                Weight = weight,
                RepRange = repRange,
                LastUpdated = lastUpdated,
                UserId = userId
            };
        }
    }
}
