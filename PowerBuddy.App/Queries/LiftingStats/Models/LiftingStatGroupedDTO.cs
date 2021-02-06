using System.Collections.Generic;
using PowerBuddy.Data.Dtos.LiftingStats;

namespace PowerBuddy.App.Queries.LiftingStats.Models
{
    public class LiftingStatGroupedDto
    {
        public string ExerciseName { get; set; }
        public IEnumerable<LiftingStatAuditDto> LiftingStats { get; set; }
    }
}
