using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Builders.DTOs.Workouts
{
	public class WorkoutExerciseDtoBuilder
	{
		private readonly Random _random;
		private readonly WorkoutExerciseDto _workoutExercise;

		public WorkoutExerciseDtoBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutExercise = new WorkoutExerciseDto
			{
				WorkoutExerciseId = _random.Next(),
				WorkoutDayId = _random.Next(),
				WorkoutSets = new List<WorkoutSetDto>(),
				ExerciseId = _random.Next()
			};
		}

		public WorkoutExerciseDto Build()
		{
			return _workoutExercise;
		}

		public WorkoutExerciseDtoBuilder WithWorkoutExerciseId(int workoutExerciseId)
		{
			_workoutExercise.WorkoutExerciseId = workoutExerciseId;
			return this;
		}

		public WorkoutExerciseDtoBuilder WithWorkoutDayId(int workoutDayId)
		{
			_workoutExercise.WorkoutDayId = workoutDayId;
			return this;
		}

		public WorkoutExerciseDtoBuilder WithExerciseId(int exerciseId)
		{
			_workoutExercise.ExerciseId = exerciseId;
			return this;
		}

		public WorkoutExerciseDtoBuilder WithComment(string comment)
		{
			_workoutExercise.Comment = comment;
			return this;
		}

		public WorkoutExerciseDtoBuilder WithWorkoutSets(IList<WorkoutSetDto> workoutSets)
		{
			_workoutExercise.WorkoutSets = workoutSets;
			return this;
		}
	}
}