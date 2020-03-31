using System;
using System.Collections.Generic;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.UserRoles.Model;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public int LiftingStatId { get; set; }
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
   
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual UserRole Role { get; set; }
    }

    //public class ApplicationUserToken : IdentityUserToken<string>
    //{
    //    public virtual ApplicationUser User { get; set; }
    //}
}

