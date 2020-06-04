using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.ProgramLogs.Repository;
using PowerLifting.Repository.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogWrapper
    {
        IProgramLogRepository ProgramLog { get; }
        IProgramLogWeekRepository ProgramLogWeek { get; }
        IProgramLogDayRepository ProgramLogDay { get; }
        IProgramLogExerciseRepository ProgramLogExercise { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
    }
}
