using System;

namespace PowerBuddy.Data.DTOs.LiftingStats
{
    public class LiftFeedDTO
    {
        public int LiftingStatAuditId { get; set; }
        public int RepRange { get; set; }
        public int LiftingStatId { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
        public string UserName { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseId { get; set; }

    }
}