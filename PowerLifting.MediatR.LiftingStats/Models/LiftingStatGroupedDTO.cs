using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Models
{
    public class LiftingStatGroupedDTO
    {
        public string ExerciseName { get; set; }
        public IEnumerable<LiftingStatDTO> LiftingStats { get; set; }
    }
}
