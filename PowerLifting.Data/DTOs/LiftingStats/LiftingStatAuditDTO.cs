using System;

namespace PowerLifting.Data.DTOs.LiftingStats
{
    public class LiftingStatAuditDTO
    {
        public int LiftingStatAuditId { get; set; }
        public int LiftingStatId { get; set; }
        public int RepRange { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }

    }
}