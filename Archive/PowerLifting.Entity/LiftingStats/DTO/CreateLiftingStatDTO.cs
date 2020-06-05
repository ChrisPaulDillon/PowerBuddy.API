using System;
namespace PowerLifting.Service.LiftingStats.DTO
{
    public class CreateLiftingStatDTO
    {
        public string UserId { get; set; }
        public string ExerciseName { get; set; }
        public int RepRange { get; set; }
        public double Weight { get; set; }
        public DateTime LastUpdated { get; set; }
        public double? GoalWeight { get; set; }
    }
}
