using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.Entities.LiftingStats
{
    public partial class LiftingStatAudit
    {
        public Exercise Exercise { get; set; }
        public User User { get; set; }
    }
}
