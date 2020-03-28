using System;

namespace Powerlifting.Service.LiftingStats.Model
{
    public class LiftingStat
    {
        public int LiftingStatId { get; set; }
        public int UserId { get; set; }
        public double? Percentage { get; set; }
        public double BenchWeight { get; set; }
        public double SquatWeight { get; set; }
        public double DeadliftWeight { get; set; }
        //public virtual User User { get; set; }
    }
}
