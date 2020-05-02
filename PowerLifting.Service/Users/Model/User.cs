using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public virtual UserSetting UserSetting { get; set; }
        public virtual ICollection<LiftingStat> LiftingStats { get; set; }
        public virtual ICollection<ProgramLog> ProgramLogs { get; set; }
        public virtual ICollection<IdentityRole> UserRoles { get; set; }
    }
}