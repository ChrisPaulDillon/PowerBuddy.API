﻿using System;

namespace PowerLifting.Data.Entities.LiftingStats
{
    /// <summary>
    /// Used to record when a user updates their lifting stats to show a timeline
    /// </summary>
    public class LiftingStatAudit
    {
        public int LiftingStatAuditId { get; set; }
        public int LiftingStatId { get; set; }
        public decimal Weight { get; set; }
        public int RepRange { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
    }
}