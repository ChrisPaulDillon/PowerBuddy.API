using System;

namespace PowerLifting.Service.LiftingStatsAudit.DTO
{
    public class LiftingStatAuditDTO
    {
        public DateTime DateChange { get; set; }
        public string Squat { get; set; }
        public string Bench { get; set; }
        public string Deadlift { get; set; }
    }
}