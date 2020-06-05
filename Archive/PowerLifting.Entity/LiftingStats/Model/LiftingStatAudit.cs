using System;

namespace PowerLifting.Service.LiftingStatsAudit.Model
{
    /// <summary>
    /// Used to record when a user updates their lifting stats to show a timeline
    /// </summary>
    public class LiftingStatAudit
    {
        public int LiftingStatAuditId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateChanged { get; set; }
        public int RepRange { get; set; }
    }
}