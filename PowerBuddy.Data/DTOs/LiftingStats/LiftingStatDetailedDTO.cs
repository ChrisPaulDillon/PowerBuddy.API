using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.LiftingStats
{
    public class LiftingStatDetailedDTO
    {
        public string ExerciseName { get; set; }
        public decimal LifeTimeTonnage { get; set; }
        public IEnumerable<LiftingStatAuditDTO> LiftingStats { get; set; }
    }
}
