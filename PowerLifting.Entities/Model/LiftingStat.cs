using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.Model
{
    public class LiftingStat
    {
        public int LiftingStatId { get; set; }
        public Double BenchWeight { get; set; }
        public Double SquatWeight { get; set; }
        public Double DeadliftWeight { get; set; }
        //public virtual User User { get; set; }
    }
}
