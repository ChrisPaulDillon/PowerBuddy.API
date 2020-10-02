using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.Entities.LiftingStats
{
    public partial class LiftingStat
    {
        public virtual Exercise Exercise { get; set; }
    }
}
