using System;

namespace PowerLifting.Data.DTOs.LiftingStats
{
    public class LiftingStatAuditDTO
    {
        public int LiftingStatAuditId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateChanged { get; set; }
        public int RepRange { get; set; }
    }
}