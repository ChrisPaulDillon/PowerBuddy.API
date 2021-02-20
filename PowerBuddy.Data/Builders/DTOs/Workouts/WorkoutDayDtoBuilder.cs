using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Builders.DTOs.Workouts
{
	public class WorkoutDayDtoBuilder
	{
		private readonly Random _random;
		private readonly WorkoutDayDto _workoutDayDto;

		public WorkoutDayDtoBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutDayDto = new WorkoutDayDto
			{
				WorkoutDayId = _random.Next(),
				WorkoutLogId = _random.Next(),
				Date = DateTime.UtcNow,
				UserId = _random.Next().ToString(),
				WorkoutExercises = new List<WorkoutExerciseDto>()
			};
		}

		public WorkoutDayDto Build()
		{
			return _workoutDayDto;
		}

		public WorkoutDayDtoBuilder WithWorkoutDayId(int workoutDayId)
		{
			_workoutDayDto.WorkoutDayId = workoutDayId;
			return this;
		}

		public WorkoutDayDtoBuilder WithWorkoutLogId(int workoutLogId)
		{
			_workoutDayDto.WorkoutDayId = workoutLogId;
			return this;
		}


		public WorkoutDayDtoBuilder WithDate(DateTime date)
		{
			_workoutDayDto.Date = date;
			return this;
		}

		public WorkoutDayDtoBuilder WithUserId(string userId)
		{
			_workoutDayDto.UserId = userId;
			return this;
		}

		public WorkoutDayDtoBuilder WithWorkoutExercises(IEnumerable<WorkoutExerciseDto> workoutExercises)
		{
			_workoutDayDto.WorkoutExercises = workoutExercises;
			return this;
		}
	}
}
