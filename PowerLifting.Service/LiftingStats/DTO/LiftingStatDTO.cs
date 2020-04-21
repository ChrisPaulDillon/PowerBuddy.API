using System;

namespace PowerLifting.Service.LiftingStats.DTO
{
    /// <summary>
    /// Represents a users lifting stats for a given rep range, user will have multiple
    /// for each rep ranges such as 1RM, 2RM, 3RM, 4RM etc
    /// </summary>
    public class LiftingStatDTO
    {
        public int LiftingStatId { get; set; }
        public string UserId { get; set; }
        public int RepRange { get; set; }
        public double BenchWeight { get; set; } = 0;
        public DateTime BenchLastUpdated { get; set; }
        public double SquatWeight { get; set; } = 0;
        public DateTime SquatLastUpdated { get; set; }
        public double DeadLiftWeight { get; set; } = 0;
        public DateTime DeadLiftLastUpdated { get; set; }
        public double OverHeadPressWeight { get; set; }
        public DateTime OverHeadPressLastUpdated { get; set; }
        public double FrontSquatWeight { get; set; }
        public DateTime FrontSquatLastUpdated { get; set; }
    }
}