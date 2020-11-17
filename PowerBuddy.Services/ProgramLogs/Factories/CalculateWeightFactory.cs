using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.Services.ProgramLogs.Factories
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
