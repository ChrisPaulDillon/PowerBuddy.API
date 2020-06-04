using PowerLifting.ProgramLogs.Repository;
using PowerLifting.Repository.ProgramLogs;

namespace PowerLifting.ProgramLogs.Service
{
    public interface IProgramLogWrapper
    {
        ProgramLogRepository ProgramLog { get; }
        ProgramLogWeekRepository ProgramLogWeek { get; }
        ProgramLogDayRepository ProgramLogDay { get; }
        ProgramLogExerciseRepository ProgramLogExercise { get; }
        ProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
    }
}
