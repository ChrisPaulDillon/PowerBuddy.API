using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Service.ProgramLogs.Strategies;

namespace PowerLifting.Service.ProgramLogs
{
    public interface IProgramLogService
    {
        IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramDTO template, DateTime startDate, string userId);

        ICollection<ProgramLogDayDTO> CreateProgramLogDaysForWeekFromTemplate(ProgramLogWeekDTO programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId);

        IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats, ICalculateRepWeight calculateRepWeight);

        CProgramLogExerciseDTO CreateRepSchemesForExercise(CProgramLogExerciseDTO programLogExercise);
    }
}
