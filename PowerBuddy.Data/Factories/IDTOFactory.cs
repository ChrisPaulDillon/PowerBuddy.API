using System;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.ProgramLogs;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.Factories
{
    public interface IDtoFactory
    {
        public LiftingStatAuditDto CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int workoutSetId, string userId);
        public WorkoutDayDto CreateWorkoutDay(DateTime date, int weekNo, string userId);
    }
}
