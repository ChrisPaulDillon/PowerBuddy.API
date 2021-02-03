using PowerBuddy.App.Services.Workouts.Strategies;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.Workouts.Factories
{
    public class CalculateWeightFactory : ICalculateWeightFactory
    {
        public ICalculateRepWeight Create(string weightProgressionType)
        {
            if (weightProgressionType == WeightProgressionTypeEnum.PERCENTAGE.ToString())
            {
                return new CalculateRepWeightPercentage();
            }
            else
            {
                return new CalculateRepWeightIncremental();
            }
        }
    }
}
