using System.Collections.Generic;
using PowerBuddy.Data.DTOs.LiftingStats;

namespace PowerBuddy.MediatR.Queries.LiftingStats.Models
{
    public class LiftingStatGroupedDTO
    {
        public string ExerciseName { get; set; }
        public IEnumerable<LiftingStatAuditDTO> LiftingStats { get; set; }
    }
}
