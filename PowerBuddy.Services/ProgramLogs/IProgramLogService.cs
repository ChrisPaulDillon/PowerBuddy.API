using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.Services.ProgramLogs
{
    public interface IProgramLogService
    {
        Task IsProgramLogAlreadyActive(DateTime startDate, DateTime endDate, string userId);

        Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);

        Task<ProgramLogExerciseTonnage> UpdateExerciseTonnage(ProgramLogExercise programLogExercise, string userId);

        IEnumerable<ProgramLogWeek> CreateProgramLogWeeksFromTemplate(TemplateProgramExtendedDTO template, DateTime startDate, string userId);

        ICollection<ProgramLogDay> CreateProgramLogDaysForWeekFromTemplate(ProgramLogWeek programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId);

        IEnumerable<ProgramLogExercise> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);

        ProgramLogExerciseDTO CreateRepSchemesForExercise(ProgramLogExerciseDTO programLogExercise, string userId);

        Task<IEnumerable<DateTime>> GetAllProgramLogDatesForUser(string userId);
    }
}
