﻿using System;
using System.Collections.Generic;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Services.ProgramLogs.DTO;

namespace Powerlifting.Services.Users.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public int LiftingStatId { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
        public ICollection<ProgramLogDTO> ProgramLogs { get; set; }

    }
}
