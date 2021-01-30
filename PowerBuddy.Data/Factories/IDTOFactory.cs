using System;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.Data.Factories
{
    public interface IDTOFactory
    {
        public LiftingStatAuditDTO CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int workoutSetId, string userId);
        public WorkoutDayDTO CreateWorkoutDay(DateTime date, int weekNo, string userId);
    }
}
