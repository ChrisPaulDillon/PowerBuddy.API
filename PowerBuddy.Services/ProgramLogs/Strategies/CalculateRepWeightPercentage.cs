using System;

namespace PowerBuddy.Services.ProgramLogs.Strategies
{
    public class CalculateRepWeightPercentage : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal percentage)
        {
            var percent = percentage / 100;
            return weightInput * percent;
        }
    }
}
