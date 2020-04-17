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

        public double DeadliftWeight { get; set; } = 0;
        //public virtual User User { get; set; }
    }
}