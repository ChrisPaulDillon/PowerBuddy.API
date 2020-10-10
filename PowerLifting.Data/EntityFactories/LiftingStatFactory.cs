using System;
using PowerLifting.Data.Entities;

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
