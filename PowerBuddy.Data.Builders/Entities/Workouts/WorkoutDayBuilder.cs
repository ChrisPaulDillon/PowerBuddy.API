using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class WorkoutDayBuilder
	{
		private readonly Random _random;
		private readonly WorkoutDay _workoutDay;

		public WorkoutDayBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutDay = new WorkoutDay
			{
				WorkoutDayId = _random.Next(),
				WorkoutLogId = _random.Next(),
				Date = DateTime.UtcNow,
				UserId = _random.Next().ToString(),
				WorkoutExercises = new List<WorkoutExercise>()
			};
		}

		public WorkoutDay Build()
		{
			return _workoutDay;
		}

		public WorkoutDayBuilder WithWorkoutDayId(int workoutDayId)
		{
			_workoutDay.WorkoutDayId = workoutDayId;
			return this;
		}

		public WorkoutDayBuilder WithWorkoutLogId(int workoutLogId)
		{
			_workoutDay.WorkoutLogId = workoutLogId;
			return this;
		}

		public WorkoutDayBuilder WithDate(DateTime date)
		{
			_workoutDay.Date = date;
			return this;
		}

		public WorkoutDayBuilder WithUserId(string userId)
		{
			_workoutDay.UserId = userId;
			return this;
		}

		public WorkoutDayBuilder WithWorkoutExercises(IEnumerable<WorkoutExercise> workoutExercises)
		{
			_workoutDay.WorkoutExercises = workoutExercises;
			return this;
		}
	}
}
