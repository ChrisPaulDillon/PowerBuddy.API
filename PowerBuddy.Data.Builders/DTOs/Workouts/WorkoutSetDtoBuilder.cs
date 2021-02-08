using System;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Builders.DTOs.Workouts
{
	public class WorkoutSetDtoBuilder
	{
		private readonly Random _random;
		private readonly WorkoutSetDto _workoutSet;

		public WorkoutSetDtoBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutSet = new WorkoutSetDto
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

		public WorkoutSetDto Build()
		{
			return _workoutSet;
		}

		public WorkoutSetDtoBuilder WithWorkoutSetId(int workoutSetId)
		{
			_workoutSet.WorkoutSetId = workoutSetId;
			return this;
		}

		public WorkoutSetDtoBuilder WithWorkoutExerciseId(int workoutExerciseId)
		{
			_workoutSet.WorkoutExerciseId = workoutExerciseId;
			return this;
		}

		public WorkoutSetDtoBuilder WithNoOfReps(int noOfReps)
		{
			_workoutSet.NoOfReps = noOfReps;
			return this;
		}

		public WorkoutSetDtoBuilder WithRepsCompleted(int repsCompleted)
		{
			_workoutSet.RepsCompleted = repsCompleted;
			return this;
		}

		public WorkoutSetDtoBuilder WithLiftingStatAuditId(int liftingStatAuditId)
		{
			_workoutSet.LiftingStatAuditId = liftingStatAuditId;
			return this;
		}

		public WorkoutSetDtoBuilder WithComment(string comment)
		{
			_workoutSet.Comment = comment;
			return this;
		}
	}
}