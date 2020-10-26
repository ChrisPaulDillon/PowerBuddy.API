using System;
using System.Collections.Generic;
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

        public ProgramLogWeek CreateProgramLogWeek(int programLogId, DateTime startDate, string userId, int weekNo)
        {
            return new ProgramLogWeek()
            {
                StartDate = startDate,
                WeekNo = weekNo,
                EndDate = startDate.AddDays(7),
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDay>()
                {
                    CreateProgramLogDay(startDate, userId),
                    CreateProgramLogDay(startDate.AddDays(1), userId),
                    CreateProgramLogDay(startDate.AddDays(2), userId),
                    CreateProgramLogDay(startDate.AddDays(3), userId),
                    CreateProgramLogDay(startDate.AddDays(4), userId),
                    CreateProgramLogDay(startDate.AddDays(5), userId),
                    CreateProgramLogDay(startDate.AddDays(6), userId),
                },
            };
        }

        public ProgramLogDay CreateProgramLogDay(DateTime date, string userId)
        {
            return new ProgramLogDay()
            {
                Date = date,
                UserId = userId,
                ProgramLogExercises = new List<ProgramLogExercise>(),
            };
        }


        public ProgramLogExerciseTonnage CreateProgramLogExerciseTonnage(int programLogExerciseId, decimal exerciseTonnage, string userId, int exerciseId)
        {
            return  new ProgramLogExerciseTonnage()
            {
                ProgramLogExerciseId = programLogExerciseId,
                ExerciseTonnage = exerciseTonnage,
                UserId = userId,
                ExerciseId = exerciseId
            };
        }
    }
}
