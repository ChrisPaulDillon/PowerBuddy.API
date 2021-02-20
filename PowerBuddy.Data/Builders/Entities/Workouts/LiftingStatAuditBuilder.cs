using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class LiftingStatAuditBuilder
	{
		private readonly LiftingStatAudit _liftingStatAudit;

		public LiftingStatAuditBuilder(Random random = null)
		{
			var random1 = random ?? new Random();
			_liftingStatAudit = new LiftingStatAudit
			{
				LiftingStatAuditId = random1.Next(),
				ExerciseId = random1.Next(),
				Weight = random1.Next(),
				RepRange = random1.Next(),
				UserId = random1.Next().ToString(),
				WorkoutSetId = random1.Next()
			};
		}

		public LiftingStatAudit Build()
		{
			return _liftingStatAudit;
		}

		public LiftingStatAuditBuilder WithLiftingStatAuditId(int liftingStatAuditId)
		{
			_liftingStatAudit.LiftingStatAuditId = liftingStatAuditId;
			return this;
		}

		public LiftingStatAuditBuilder WithExerciseId(int exerciseId)
		{
			_liftingStatAudit.ExerciseId = exerciseId;
			return this;
		}

		public LiftingStatAuditBuilder WithWeight(decimal weight)
		{
			_liftingStatAudit.Weight = weight;
			return this;
		}

		public LiftingStatAuditBuilder WithRepRange(int repRange)
		{
			_liftingStatAudit.RepRange = repRange;
			return this;
		}

		public LiftingStatAuditBuilder WithUserId(string userId)
		{
			_liftingStatAudit.UserId = userId;
			return this;
		}

		public LiftingStatAuditBuilder WithWorkoutSetId(int workoutSetId)
		{
			_liftingStatAudit.WorkoutSetId = workoutSetId;
			return this;
		}
	}
}
