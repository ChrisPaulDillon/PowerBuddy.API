using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Service
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
