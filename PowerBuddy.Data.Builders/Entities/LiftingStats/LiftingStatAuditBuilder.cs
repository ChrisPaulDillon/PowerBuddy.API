using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.LiftingStats
{
    public class LiftingStatAuditBuilder
    {
        private readonly Random _random;
        private readonly LiftingStatAudit _liftingStatAudit;

        public LiftingStatAuditBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _liftingStatAudit = new LiftingStatAudit()
            {
                LiftingStatAuditId = _random.Next(),
                UserId = _random.Next().ToString(),
                ExerciseId = _random.Next(),
                RepRange = _random.Next(),
                Weight = _random.Next(),
            };
        }

        public LiftingStatAudit Build()
        {
            return _liftingStatAudit;
        }

        public LiftingStatAuditBuilder WithLiftingStatId(int liftingStatId)
        {
            _liftingStatAudit.LiftingStatAuditId = liftingStatId;
            return this;
        }

        public LiftingStatAuditBuilder WithUserId(string userId)
        {
            _liftingStatAudit.UserId = userId;
            return this;
        }

        public LiftingStatAuditBuilder WithExerciseId(int exerciseId)
        {
            _liftingStatAudit.ExerciseId = exerciseId;
            return this;
        }

        public LiftingStatAuditBuilder WithRepRange(int repRange)
        {
            _liftingStatAudit.RepRange = repRange;
            return this;
        }

        public LiftingStatAuditBuilder WithWeight(decimal weight)
        {
            _liftingStatAudit.Weight = weight;
            return this;
        }
    }
}
