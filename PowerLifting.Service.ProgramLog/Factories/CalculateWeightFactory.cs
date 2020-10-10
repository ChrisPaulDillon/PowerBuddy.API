using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;
using PowerLifting.Service.ProgramLogs.Strategies;

namespace PowerLifting.Service.ProgramLogs.Factories
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
