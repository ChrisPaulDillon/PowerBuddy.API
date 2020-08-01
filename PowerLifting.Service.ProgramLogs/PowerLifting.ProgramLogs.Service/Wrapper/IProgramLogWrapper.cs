using PowerLifting.ProgramLogs.Repository;

namespace PowerLifting.ProgramLogs.Service.Wrapper
{
    public interface IProgramLogWrapper
    {
        IProgramLogRepository ProgramLog { get; }
        IProgramLogWeekRepository ProgramLogWeek { get; }
        IProgramLogRepSchemeRepository ProgramLogRepScheme { get; }
    }
}
