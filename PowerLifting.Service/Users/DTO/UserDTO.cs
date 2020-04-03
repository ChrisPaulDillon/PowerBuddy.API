using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Services.ProgramLogs.DTO;

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
