using System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStat CreateLiftingStat(int exerciseId, decimal weight, int repRange, string userId, DateTime? lastUpdated = null);

        //ProgramLogs
        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted);
        public ProgramLogWeek CreateProgramLogWeek(DateTime startDate, int weekNo, string userId);
        public ProgramLogWeek CreateProgramLogWeekWithDays(DateTime startDate, int weekNo, string userId);
        public ProgramLogDay CreateProgramLogDay(DateTime date, string userId);
        public ProgramLogExercise CreateProgramLogExercise(int noOfSets, int exerciseId);

        public ProgramLogRepScheme CreateProgramLogRepScheme(int setNo, int noOfReps, decimal percentage, decimal weightLifted, bool amrap);
        public ProgramLogExerciseTonnage CreateProgramLogExerciseTonnage(int programLogExerciseId, decimal exerciseTonnage, string userId, int exerciseId);
    }
}
