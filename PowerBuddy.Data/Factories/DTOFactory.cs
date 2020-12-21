using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;

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

        public ProgramLogWeekDTO CreateProgramLogWeekDTO(DateTime date, int weekNo, string userId)
        {
            return new ProgramLogWeekDTO()
            {
                StartDate = date,
                WeekNo = weekNo,
                EndDate = date.AddDays(6),
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDayDTO>()
                {
                    CreateProgramLogDayDTO(date, userId),
                    CreateProgramLogDayDTO(date.AddDays(1), userId),
                    CreateProgramLogDayDTO(date.AddDays(2), userId),
                    CreateProgramLogDayDTO(date.AddDays(3), userId),
                    CreateProgramLogDayDTO(date.AddDays(4), userId),
                    CreateProgramLogDayDTO(date.AddDays(5), userId),
                    CreateProgramLogDayDTO(date.AddDays(6), userId),
                },
            };
        }

        public ProgramLogDayDTO CreateProgramLogDayDTO(DateTime date, string userId)
        {
            return new ProgramLogDayDTO()
            {
                Date = date,
                UserId = userId,
                ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
            };
        }

        public ProgramLogRepSchemeDTO CreateProgramLogRepSchemeDTO(int setNo, int noOfReps, decimal weightLifted)
        {
            return new ProgramLogRepSchemeDTO()
            {
                SetNo = setNo,
                NoOfReps = noOfReps,
                WeightLifted = weightLifted
            };
        }

        public ProgramLogExerciseTonnageDTO CreateProgramLogExerciseTonnageDTO(int programLogExerciseId, decimal exerciseWeight, string userId, int exerciseId)
        {
            return new ProgramLogExerciseTonnageDTO()
            {
                ProgramLogExerciseId = programLogExerciseId,
                ExerciseTonnage = exerciseWeight,
                UserId = userId,
                ExerciseId = exerciseId
            };
        }
    }
}
