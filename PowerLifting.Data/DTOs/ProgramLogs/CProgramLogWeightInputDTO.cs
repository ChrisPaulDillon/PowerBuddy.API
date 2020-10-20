using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class CProgramLogWeightInputDTO : ProgramLogInputDTO
    {
        public IList<LiftingStat> WeightInputs { get; set; }
    }
}