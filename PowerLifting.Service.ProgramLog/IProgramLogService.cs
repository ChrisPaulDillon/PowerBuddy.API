using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.Service.ProgramLogs
{
    public interface IProgramLogService
    {
        IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramDTO template, DateTime startDate, string userId);

        ICollection<ProgramLogDayDTO> CreateProgramLogDaysForWeekFromTemplate(ProgramLogWeekDTO programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId);

        IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForDay(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats);
    }
}
