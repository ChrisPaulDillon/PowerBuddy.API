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
