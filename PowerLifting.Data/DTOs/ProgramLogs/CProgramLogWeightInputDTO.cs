using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.LiftingStats;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class CProgramLogWeightInputDTO : CProgramLogDTO
    {
        public IList<LiftingStat> WeightInputs { get; set; }
    }
}