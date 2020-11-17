using System.Collections.Generic;
using PowerBuddy.Data.DTOs.LiftingStats;

namespace PowerBuddy.MediatR.LiftingStats.Models
{
    public class LiftingStatGroupedDTO
    {
        public string ExerciseName { get; set; }
        public IEnumerable<LiftingStatDTO> LiftingStats { get; set; }
    }
}
