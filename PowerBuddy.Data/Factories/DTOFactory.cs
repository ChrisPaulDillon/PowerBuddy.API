using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.ProgramLogs;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Factories
{
    public class DtoFactory : IDtoFactory
    {
        public LiftingStatAuditDto CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int workoutSetId, string userId)
        {
            return new LiftingStatAuditDto()
            {
                RepRange = repRange,
                ExerciseId = exerciseId,
                Weight = weight,
                DateChanged = date,
                WorkoutSetId = workoutSetId,
                UserId = userId,
            };
        }

        public WorkoutDayDto CreateWorkoutDay(DateTime date, int weekNo, string userId)
        {
            return new WorkoutDayDto()
            {
                Date = date,
                WeekNo = weekNo,
                UserId = userId,
                WorkoutExercises = new List<WorkoutExerciseDto>(),
            };
        }
    }
}
