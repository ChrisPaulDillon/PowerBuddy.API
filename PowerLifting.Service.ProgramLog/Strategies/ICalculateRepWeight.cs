﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Service.ProgramLogs.Strategies
{
    public interface ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal user1RM, decimal percentage);
    }
}
