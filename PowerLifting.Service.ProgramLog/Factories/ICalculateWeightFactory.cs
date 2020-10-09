using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Service.ProgramLogs.Strategies;

namespace PowerLifting.Service.ProgramLogs.Factories
{
    public interface ICalculateWeightFactory
    {
        public ICalculateRepWeight Create(string weightProgressionType);
    }
}
