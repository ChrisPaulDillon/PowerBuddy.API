using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class WorkoutDayBuilder
	{
		private readonly Random _random;
		private readonly WorkoutDay _workoutDayDto;

		public WorkoutDayBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutDayDto = new WorkoutDay
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
			return _workoutDayDto;
		}

		public WorkoutDayBuilder WithWorkoutDayId(int workoutDayId)
		{
			_workoutDayDto.WorkoutDayId = workoutDayId;
			return this;
		}

		public WorkoutDayBuilder WithWorkoutLogId(int workoutLogId)
		{
			_workoutDayDto.WorkoutDayId = workoutLogId;
			return this;
		}

		public WorkoutDayBuilder WithDate(DateTime date)
		{
			_workoutDayDto.Date = date;
			return this;
		}

		public WorkoutDayBuilder WithUserId(string userId)
		{
			_workoutDayDto.UserId = userId;
			return this;
		}

		public WorkoutDayBuilder WithWorkoutExercises(IEnumerable<WorkoutExercise> workoutExercises)
		{
			_workoutDayDto.WorkoutExercises = workoutExercises;
			return this;
		}
	}
}
