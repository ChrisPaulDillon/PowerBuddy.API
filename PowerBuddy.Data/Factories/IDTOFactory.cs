using System;
using PowerBuddy.Data.DTOs.ProgramLogs;

namespace PowerBuddy.Data.Factories
{
    public interface IDTOFactory
    {
        public ProgramLogWeekDTO CreateProgramLogWeekDTO(DateTime date, int weekNo, string userId);
        public ProgramLogDayDTO CreateProgramLogDayDTO(DateTime date, string userId);

        public ProgramLogRepSchemeDTO CreateProgramLogRepSchemeDTO(int setNo, int noOfReps, decimal weightLifted);

        public ProgramLogExerciseTonnageDTO CreateProgramLogExerciseTonnageDTO(int programLogExerciseId, decimal exerciseWeight, string userId, int exerciseId);
    }
}
