using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Entities.Model;

namespace PowerLifting.Entities.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public virtual LiftingStatsDTO LiftingStats { get; set; }
        public ICollection<ProgramLogDTO> ProgramLogs { get; set; }
    }
}