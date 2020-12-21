using System;

namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// Used to record when a user updates their lifting stats to show a timeline
    /// </summary>
    public partial class LiftingStatAudit
    {
        public int LiftingStatAuditId { get; set; }
        public int ExerciseId { get; set; }
        public decimal Weight { get; set; }
        public int RepRange { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
        public int WorkoutSetId { get; set; }
    }
}