using System;

namespace PowerBuddy.Data.DTOs.LiftingStats
{
    /// <summary>
    /// Represents a users lifting stats for a given rep range, user will have multiple
    /// for each rep ranges such as 1RM, 2RM, 3RM, 4RM etc
    /// </summary>
    public class LiftingStatDTO
    {
        public int LiftingStatId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public int RepRange { get; set; }
        public decimal? Weight { get; set; }
        public decimal? GoalWeight { get; set; }
        public decimal? PercentageToGoal { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string ExerciseName { get; set; }
    }
}