using System;

namespace PowerBuddy.Services.ProgramLogs.Strategies
{
    public class CalculateRepWeightPercentage : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal percentage)
        {
            var percent = percentage / 100;
            return Math.Round((decimal)(weightInput * percent * 2), MidpointRounding.AwayFromZero) / 2;
        }
    }
}
