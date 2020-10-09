using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.ProgramLogs.Strategies
{
    public class CalculateRepWeightPercentage : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal user1RM, decimal percentage)
        {
            var percent = percentage / 100;
            return Math.Round((decimal)(user1RM * percent * 2), MidpointRounding.AwayFromZero) / 2;
        }
    }
}
