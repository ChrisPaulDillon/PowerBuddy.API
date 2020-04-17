using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.ProgramLogs.DTO;

namespace PowerLifting.Service.Users.DTO
{
    public class UserDTO : IdentityUser
    {
        public int UserId { get; set; }
        public int LiftingStatId { get; set; }
        public string Password { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
        public ICollection<ProgramLogDTO> ProgramLogs { get; set; }
    }
}