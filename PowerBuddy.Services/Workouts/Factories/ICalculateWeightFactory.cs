using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.Services.Workouts.Factories
{
    public interface ICalculateWeightFactory
    {
        public ICalculateRepWeight Create(string weightProgressionType);
    }
}
