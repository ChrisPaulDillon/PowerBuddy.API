using PowerBuddy.App.Services.Workouts.Strategies;

namespace PowerBuddy.App.Services.Workouts.Factories
{
    public interface ICalculateWeightFactory
    {
        public ICalculateRepWeight Create(string weightProgressionType);
    }
}
