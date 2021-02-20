using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Builders.Entities.Workouts
{
	public class WorkoutLogBuilder
	{
		private readonly Random _random;
		private readonly WorkoutLog _workoutLog;

		public WorkoutLogBuilder(Random random = null)
		{
			_random = random ?? new Random();
			_workoutLog = new WorkoutLog
			{
				WorkoutLogId = _random.Next(),
				UserId = _random.Next().ToString(),
				CustomName = _random.Next().ToString(),
				WorkoutDays = new List<WorkoutDay>()
			};
		}

		public WorkoutLog Build()
		{
			return _workoutLog;
		}

		public WorkoutLogBuilder WithWorkoutLogId(int workoutLogId)
		{
			_workoutLog.WorkoutLogId = workoutLogId;
			return this;
		}

		public WorkoutLogBuilder WithUserId(string userId)
		{
			_workoutLog.UserId = userId;
			return this;
		}

        public WorkoutLogBuilder WithCustomName(string customName)
        {
            _workoutLog.CustomName = customName;
            return this;
        }

		public WorkoutLogBuilder WithWorkoutDays(IEnumerable<WorkoutDay> workoutDays)
		{
			_workoutLog.WorkoutDays = workoutDays;
			return this;
		}
	}
}
