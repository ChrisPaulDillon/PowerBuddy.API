using System;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.Data.Factories
{
    public interface IDTOFactory
    {
        public LiftingStatAuditDTO CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int programLogRepSchemeId, string userId);
        public WorkoutDayDTO CreateWorkoutDay(DateTime date, int weekNo, string userId);
        public ProgramLogWeekDTO CreateProgramLogWeekDTO(DateTime date, int weekNo, string userId);
        public ProgramLogDayDTO CreateProgramLogDayDTO(DateTime date, string userId);

        public ProgramLogRepSchemeDTO CreateProgramLogRepSchemeDTO(int setNo, int noOfReps, decimal weightLifted);

        public ProgramLogExerciseTonnageDTO CreateProgramLogExerciseTonnageDTO(int programLogExerciseId, decimal exerciseWeight, string userId, int exerciseId);
    }
}
