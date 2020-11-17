using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.Services.ProgramLogs.Factories
{
    public interface ICalculateWeightFactory
    {
        public ICalculateRepWeight Create(string weightProgressionType);
    }
}
