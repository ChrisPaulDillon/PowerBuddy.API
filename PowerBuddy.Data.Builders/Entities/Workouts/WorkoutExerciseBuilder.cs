using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class WorkoutExerciseBuilder
	{
		private readonly Random _random;
		private readonly WorkoutExercise _workoutExercise;

		public WorkoutExerciseBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutExercise = new WorkoutExercise
			{
				WorkoutExerciseId = _random.Next(),
				WorkoutDayId = _random.Next(),
				WorkoutSets = new List<WorkoutSet>(),
				ExerciseId = _random.Next()
			};
		}

		public WorkoutExercise Build()
		{
			return _workoutExercise;
		}

		public WorkoutExerciseBuilder WithWorkoutExerciseId(int workoutExerciseId)
		{
			_workoutExercise.WorkoutExerciseId = workoutExerciseId;
			return this;
		}

		public WorkoutExerciseBuilder WithWorkoutDayId(int workoutDayId)
		{
			_workoutExercise.WorkoutDayId = workoutDayId;
			return this;
		}

		public WorkoutExerciseBuilder WithExerciseId(int exerciseId)
		{
			_workoutExercise.ExerciseId = exerciseId;
			return this;
		}

		public WorkoutExerciseBuilder WithComment(string comment)
		{
			_workoutExercise.Comment = comment;
			return this;
		}

		public WorkoutExerciseBuilder WithWorkoutSets(IList<WorkoutSet> workoutSets)
		{
			_workoutExercise.WorkoutSets = workoutSets;
			return this;
		}
	}
}