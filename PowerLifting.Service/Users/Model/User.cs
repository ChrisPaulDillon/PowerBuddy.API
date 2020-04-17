using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.Users.Model
{
    public class User : IdentityUser
    {
        public virtual LiftingStat LiftingStats { get; set; }
        public ICollection<ProgramLog> ProgramLogs { get; set; }
        public virtual ICollection<IdentityRole> UserRoles { get; set; }
    }
}