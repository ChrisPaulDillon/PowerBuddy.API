using System;

namespace PowerLifting.Data.DTOs.Account
{
    public class CreateLiftingStatDTO
    {
        public string UserId { get; set; }
        public string ExerciseName { get; set; }
        public int RepRange { get; set; }
        public decimal Weight { get; set; }
        public DateTime LastUpdated { get; set; }
        public decimal? GoalWeight { get; set; }
    }
}
