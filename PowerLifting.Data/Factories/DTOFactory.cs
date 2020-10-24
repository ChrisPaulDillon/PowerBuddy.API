using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Data.Factories
{
    public class DTOFactory : IDTOFactory
    {
        public CProgramLogDayDTO CreateProgramLogDayDTO(DateTime date, string userId)
        {
            return new CProgramLogDayDTO()
            {
                Date = date,
                UserId = userId,
                ProgramLogExercises = new List<CProgramLogExerciseDTO>(),
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
