using System;

namespace PowerLifting.Service.LiftingStats.Model
{
    public class LiftingStat
    {
        public int LiftingStatId { get; set; }
        public string UserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public double BenchWeight { get; set; } = 0;
        public double SquatWeight { get; set; } = 0;
        public double DeadLiftWeight { get; set; } = 0;
        public double OverHeadPressWeight { get; set; }
        public double FrontSquatWeight { get; set; }


    }
}