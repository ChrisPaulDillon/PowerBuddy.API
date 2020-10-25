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

        IEnumerable<CProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramExtendedDTO template, DateTime startDate, string userId);

        ICollection<CProgramLogDayDTO> CreateProgramLogDaysForWeekFromTemplate(CProgramLogWeekDTO programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId);

        IEnumerable<CProgramLogExerciseDTO> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats, ICalculateRepWeight calculateRepWeight, string userId);

        CProgramLogExerciseDTO CreateRepSchemesForExercise(CProgramLogExerciseDTO programLogExercise, string userId);
    }
}
