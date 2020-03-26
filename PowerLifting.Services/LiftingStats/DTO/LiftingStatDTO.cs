using System;

namespace Powerlifting.Service.LiftingStats.DTO
{
    public class LiftingStatDTO
    {
        public int LiftingStatId { get; set; }
        public Double BenchWeight { get; set; }
        public Double SquatWeight { get; set; }
        public Double DeadliftWeight { get; set; }

        //public virtual UserDTO User { get; set; }
    }
}
