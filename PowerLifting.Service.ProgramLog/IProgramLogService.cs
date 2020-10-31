using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Service.ProgramLogs.Strategies;

namespace PowerLifting.Service.ProgramLogs
{
    public interface IProgramLogService
    {
        Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);

        Task IsProgramLogAlreadyActive(string userId);

        Task UpdateExerciseTonnage(ProgramLogExercise programLogExercise, string userId);

        IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramExtendedDTO template, DateTime startDate, string userId);

        ICollection<ProgramLogDayDTO> CreateProgramLogDaysForWeekFromTemplate(ProgramLogWeekDTO programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId);

        IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);

        ProgramLogExerciseDTO CreateRepSchemesForExercise(ProgramLogExerciseDTO programLogExercise, string userId);
    }
}
