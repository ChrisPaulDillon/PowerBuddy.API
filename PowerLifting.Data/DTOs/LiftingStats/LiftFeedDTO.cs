using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.LiftingStats
{
    public class LiftFeedDTO
    {
        public int RepRange { get; set; }
        public decimal Weight { get; set; }
        public string UserId { get; set; }
        public DateTime DateChanged { get; set; }
        public string UserName { get; set; }
        public string ExerciseName { get; set; }

    }
}