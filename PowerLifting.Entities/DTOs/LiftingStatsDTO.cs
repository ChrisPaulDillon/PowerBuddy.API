using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Entities.DTOs
{
    public class LiftingStatsDTO
    {
        public int LiftingStatsId { get; set; }
        public virtual UserDTO User { get; set; }
        public Double BenchWeight { get; set; }
        public Double SquatWeight { get; set; }
        public Double DeadliftWeight { get; set; }
    }
}
