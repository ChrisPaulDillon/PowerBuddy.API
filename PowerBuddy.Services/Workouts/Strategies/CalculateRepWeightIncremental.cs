using System;

namespace PowerBuddy.Services.Workouts.Strategies
{
    public class CalculateRepWeightIncremental : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal baseIncrementalJump)
        {
            return Math.Round((weightInput + baseIncrementalJump) * 4, MidpointRounding.ToEven) / 4;
        }
    }
}
