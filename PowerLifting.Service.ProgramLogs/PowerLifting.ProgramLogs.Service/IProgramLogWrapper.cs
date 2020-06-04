using System;
using PowerLifting.ProgramLogs.Contracts;

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
