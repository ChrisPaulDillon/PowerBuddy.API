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
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
   

    public class ApplicationRole : IdentityRole<string>
    {
        public string ApplicationRoleId { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public string ApplicationUserRoleId { get; set; }
        public virtual User User { get; set; }
        public virtual ApplicationRole Role { get; set; }
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
        public virtual ApplicationRole Role { get; set; }
    }

    //public class ApplicationUserToken : IdentityUserToken<string>
    //{
    //    public virtual ApplicationUser User { get; set; }
    //}
}

