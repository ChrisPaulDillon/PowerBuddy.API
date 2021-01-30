using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.Data.Factories
{
    public class DTOFactory : IDTOFactory
    {
        public LiftingStatAuditDTO CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int workoutSetId, string userId)
        {
            return new LiftingStatAuditDTO()
            {
                RepRange = repRange,
                ExerciseId = exerciseId,
                Weight = weight,
                DateChanged = date,
                WorkoutSetId = workoutSetId,
                UserId = userId,
            };
        }

        public WorkoutDayDTO CreateWorkoutDay(DateTime date, int weekNo, string userId)
        {
            return new WorkoutDayDTO()
            {
                Date = date,
                WeekNo = weekNo,
                UserId = userId,
                WorkoutExercises = new List<WorkoutExerciseDTO>(),
            };
        }
    }
}
