using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.LiftingStats
{
    public class LiftingStatDetailedDto
    {
        public string ExerciseName { get; set; }
        public decimal LifeTimeTonnage { get; set; }
        public IEnumerable<LiftingStatAuditDto> LiftingStats { get; set; }
    }
}
