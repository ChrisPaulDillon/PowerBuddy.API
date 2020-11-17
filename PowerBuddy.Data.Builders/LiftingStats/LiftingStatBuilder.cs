using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.LiftingStats
{
    public class LiftingStatBuilder
    {
        private readonly Random _random;
        private readonly LiftingStat _liftingStat;

        public LiftingStatBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _liftingStat = new LiftingStat()
            {
                LiftingStatId = _random.Next(),
                UserId = _random.Next().ToString(),
                ExerciseId = _random.Next(),
                RepRange = _random.Next(),
                Weight = _random.Next(),
            };
        }

        public LiftingStat Build()
        {
            return _liftingStat;
        }

        public LiftingStatBuilder WithLiftingStatId(int liftingStatId)
        {
            _liftingStat.LiftingStatId = liftingStatId;
            return this;
        }

        public LiftingStatBuilder WithUserId(string userId)
        {
            _liftingStat.UserId = userId;
            return this;
        }

        public LiftingStatBuilder WithExerciseId(int exerciseId)
        {
            _liftingStat.ExerciseId = exerciseId;
            return this;
        }

        public LiftingStatBuilder WithRepRange(int repRange)
        {
            _liftingStat.RepRange = repRange;
            return this;
        }

        public LiftingStatBuilder WithWeight(decimal weight)
        {
            _liftingStat.Weight = weight;
            return this;
        }
    }
}
