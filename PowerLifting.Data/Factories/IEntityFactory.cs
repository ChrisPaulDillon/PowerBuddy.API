using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Factories
{
    public interface IEntityFactory
    {
        public LiftingStat CreateLiftingStat(int exerciseId, decimal weight, int repRange, string userId, DateTime? lastUpdated = null);

        public TonnageDayExercise CreateTonnageDayExercise(int programLogId, int programLogDayId, int exerciseId, decimal dayTonnage, string userId);

        //ProgramLogs

        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted);
    }
}
