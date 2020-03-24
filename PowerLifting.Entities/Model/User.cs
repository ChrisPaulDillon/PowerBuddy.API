using System;
using System.Collections.Generic;

namespace PowerLifting.Entities.Model
{
    public class User
    {
        public int UserId { get; set; }
        public int LiftingStatId { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }

    }
}
