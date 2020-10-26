using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Data.Factories
{
    public interface IDTOFactory
    {
        public ProgramLogWeekDTO CreateProgramLogWeekDTO(DateTime date, int weekNo, string userId);
        public ProgramLogDayDTO CreateProgramLogDayDTO(DateTime date, string userId);

        public ProgramLogRepSchemeDTO CreateProgramLogRepSchemeDTO(int setNo, int noOfReps, decimal weightLifted);

        public ProgramLogExerciseTonnageDTO CreateProgramLogExerciseTonnageDTO(int programLogExerciseId, decimal exerciseWeight, string userId, int exerciseId);
    }
}
