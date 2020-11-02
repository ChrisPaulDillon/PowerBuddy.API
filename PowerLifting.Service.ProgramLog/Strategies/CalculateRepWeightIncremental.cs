using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.ProgramLogs.Strategies
{
    public class CalculateRepWeightIncremental : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal baseIncrementalJump)
        {
            return weightInput + baseIncrementalJump;
        }
    }
}
