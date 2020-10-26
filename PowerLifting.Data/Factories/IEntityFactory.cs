using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStat CreateLiftingStat(int exerciseId, decimal weight, int repRange, string userId, DateTime? lastUpdated = null);

        //ProgramLogs
        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted);
        public ProgramLogWeek CreateProgramLogWeek(int programLogId, DateTime startDate, string userId, int weekNo);
        public ProgramLogDay CreateProgramLogDay(DateTime date, string userId);

        public ProgramLogExerciseTonnage CreateProgramLogExerciseTonnage(int programLogExerciseId, decimal exerciseTonnage, string userId, int exerciseId);
    }
}
