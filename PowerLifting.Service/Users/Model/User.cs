using System.Collections.Generic;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }
        public virtual ICollection<IdentityRole> UserRoles { get; set; }
    }

    //public class ApplicationUserToken : IdentityUserToken<string>
    //{
    //    public virtual ApplicationUser User { get; set; }
    //}
}

