using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class WorkoutSetBuilder
	{
		private readonly Random _random;
		private readonly WorkoutSet _workoutSet;

		public WorkoutSetBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutSet = new WorkoutSet
			{
				WorkoutSetId = _random.Next(),
				WorkoutExerciseId = _random.Next(),
				NoOfReps = _random.Next(),
				WeightLifted = _random.Next(),
				Comment = _random.Next().ToString(),
				AMRAP = false,
				RepsCompleted = _random.Next(),
				LiftingStatAuditId = _random.Next(),
			};
		}

		public WorkoutSet Build()
		{
			return _workoutSet;
		}

		public WorkoutSetBuilder WithWorkoutSetId(int workoutExerciseId)
		{
			_workoutSet.WorkoutSetId = workoutExerciseId;
			return this;
		}

		public WorkoutSetBuilder WithWorkoutExerciseId(int workoutExerciseId)
		{
			_workoutSet.WorkoutExerciseId = workoutExerciseId;
			return this;
		}

		public WorkoutSetBuilder WithNoOfReps(int noOfReps)
		{
			_workoutSet.NoOfReps = noOfReps;
			return this;
		}

		public WorkoutSetBuilder WithRepsCompleted(int repsCompleted)
		{
			_workoutSet.RepsCompleted = repsCompleted;
			return this;
		}

		public WorkoutSetBuilder WithLiftingStatAuditId(int liftingStatAuditId)
		{
			_workoutSet.LiftingStatAuditId = liftingStatAuditId;
			return this;
		}

		public WorkoutSetBuilder WithComment(string comment)
		{
			_workoutSet.Comment = comment;
			return this;
		}
	}
}