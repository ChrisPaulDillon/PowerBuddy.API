using PowerBuddy.Data.Entities;
using PowerBuddy.Services.Workouts.Strategies;

namespace PowerBuddy.Services.Workouts.Factories
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
