using System;
using System.Collections.Generic;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public int LiftingStatId { get; set; }
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }
    }
}
