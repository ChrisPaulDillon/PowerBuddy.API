using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.Data.Entities.Account
{
    public class User : IdentityUser
    {
        public int LiftingStatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPublic { get; set; } = true;
        public string SportType { get; set; }
        public UserSetting UserSetting { get; set; }
    }
}