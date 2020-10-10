using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;

namespace PowerLifting.Service.Tonnages
{
    public interface  ITonnageService
    {
        public Task<IEnumerable<TonnageDayExercise>> CreateTonnageBreakdownForDay(int programLogId, int programLogDayId, string userId);

        public Task<IEnumerable<ProgramLogExerciseDTO>> AssignProgramLogExercisesTonnageId(IEnumerable<ProgramLogExerciseDTO> programLogExercises);
    }
}
