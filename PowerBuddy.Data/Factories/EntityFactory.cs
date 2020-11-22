using System;
using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Factories
{
    public class EntityFactory : IEntityFactory
    {
        public LiftingStatAudit CreateLiftingStatAudit(int exerciseId, int repRange, decimal weight, DateTime date, int programLogRepSchemeId, string userId)
        {
            return new LiftingStatAudit()
            {
                RepRange = repRange,
                ExerciseId = exerciseId,
                Weight = weight,
                DateChanged = date,
                ProgramLogRepSchemeId = programLogRepSchemeId,
                UserId = userId,
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

        public ProgramLogWeek CreateProgramLogWeek(DateTime startDate, int weekNo, string userId)
        {
            return new ProgramLogWeek()
            {
                StartDate = startDate,
                WeekNo = weekNo,
                EndDate = startDate.AddDays(7),
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDay>()
            };
        }

        public ProgramLogWeek CreateProgramLogWeekWithDays(DateTime startDate, int weekNo, string userId)
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

        public ProgramLogExercise CreateProgramLogExercise(int noOfSets, int exerciseId)
        {
            return new ProgramLogExercise()
            {
                NoOfSets = noOfSets,
                ExerciseId = exerciseId, 
                ProgramLogRepSchemes = new List<ProgramLogRepScheme>(),
                ProgramLogExerciseTonnage = new ProgramLogExerciseTonnage()
            };
        }

        public ProgramLogRepScheme CreateProgramLogRepScheme(int setNo, int noOfReps, decimal percentage, decimal weightLifted, bool amrap)
        {
            return new ProgramLogRepScheme()
            {
                SetNo = setNo,
                NoOfReps = noOfReps,
                Percentage = percentage,
                WeightLifted = weightLifted,
                AMRAP = amrap,
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
