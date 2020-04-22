using System;

namespace PowerLifting.Service.LiftingStatsAudit.DTO
{
    public class LiftingStatAuditDTO
    {
        public int LiftingStatAuditId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateChange { get; set; }
        public int RepRange { get; set; }
    }
}