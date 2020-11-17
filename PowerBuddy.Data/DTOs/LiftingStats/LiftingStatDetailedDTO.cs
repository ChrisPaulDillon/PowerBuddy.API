using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.LiftingStats
{
    public class LiftingStatDetailedDTO
    {
        public string ExerciseName { get; set; }
        public decimal LifeTimeTonnage { get; set; }
        public IEnumerable<LiftingStatDTO> LiftingStats { get; set; }
        public IEnumerable<LiftFeedDTO> LiftFeed { get; set; }
    }
}
