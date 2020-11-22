using System;

namespace PowerBuddy.Data.DTOs.LiftingStats
{
    public class LiftingStatAuditDTO
    {
        public int LiftingStatAuditId { get; set; }
        public int RepRange { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
        public int ExerciseId { get; set; }
        public int ProgramLogRepSchemeId { get; set; }
        public string ExerciseName { get; set; }

    }
}