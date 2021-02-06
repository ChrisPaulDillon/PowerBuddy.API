using System;

namespace PowerBuddy.Data.Dtos.LiftingStats
{
    public class LiftingStatAuditDto
    {
        public int LiftingStatAuditId { get; set; }
        public int RepRange { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutSetId { get; set; }
        public string ExerciseName { get; set; }

    }
}