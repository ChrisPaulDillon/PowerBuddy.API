using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPublic { get; set; } = true;
        public string SportType { get; set; }
        public virtual UserSetting UserSetting { get; set; }
        public virtual IEnumerable<LiftingStat> LiftingStats { get; set; }
        public virtual IEnumerable<ProgramLog> ProgramLogs { get; set; }
        public virtual IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}