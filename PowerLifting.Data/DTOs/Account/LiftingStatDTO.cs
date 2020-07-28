using System;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Data.DTOs.Account
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
        public double? Weight { get; set; }
        public double? GoalWeight { get; set; }
        public double? PercentageToGoal { get; set; }
        public DateTime? LastUpdated { get; set; }
        public virtual TopLevelExerciseDTO Exercise { get; set; }
    }
}