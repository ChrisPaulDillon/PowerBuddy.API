using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Factories
{
    public class EntityFactory : IEntityFactory
    {
        public LiftingStat CreateLiftingStat(int exerciseId, decimal weight, int repRange, string userId, DateTime? lastUpdated = null)
        {
            return new LiftingStat()
            {
                ExerciseId = exerciseId,
                Weight = weight,
                RepRange = repRange,
                LastUpdated = lastUpdated ?? DateTime.UtcNow,
                UserId = userId
            };
        }

        public TonnageDayExercise CreateTonnageDayExercise(int programLogId, int programLogDayId, int exerciseId, decimal dayTonnage, string userId)
        {
            return new TonnageDayExercise()
            {
                ProgramLogId = programLogId,
                ProgramLogDayId = programLogDayId,
                ExerciseId = exerciseId,
                DayTonnage = dayTonnage,
                UserId = userId
            };
        }

        public ProgramLogRepScheme CreateRepScheme(int programLogExerciseId, int setNo, int noOfReps, decimal weightLifted)
        {
            return new ProgramLogRepScheme()
            {
                ProgramLogExerciseId = programLogExerciseId,
                SetNo = setNo,
                NoOfReps = noOfReps,
                WeightLifted = weightLifted
            };
        }
    }
}
