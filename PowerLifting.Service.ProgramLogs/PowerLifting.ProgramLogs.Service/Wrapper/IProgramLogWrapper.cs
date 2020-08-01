using PowerLifting.ProgramLogs.Repository;

namespace PowerLifting.ProgramLogs.Service.Wrapper
{
    public interface IProgramLogWrapper
    {
        IProgramLogWeekRepository ProgramLogWeek { get; }
    }
}
