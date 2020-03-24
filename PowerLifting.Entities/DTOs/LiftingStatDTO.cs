using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.DTOs
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
