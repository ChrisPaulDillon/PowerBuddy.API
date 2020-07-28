using PowerLifting.ProgramLogs.Repository;

namespace PowerLifting.ProgramLogs.Service.Wrapper
{
    public interface IProgramLogWrapper
    {
        IProgramLogRepository ProgramLog { get; }
        IProgramLogWeekRepository ProgramLogWeek { get; }
        IProgramLogDayRepository ProgramLogDay { get; }
        IProgramLogExerciseRepository ProgramLogExercise { get; }
        IProgramLogExerciseAuditRepository ProgramLogExerciseAudit { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
    }
}
