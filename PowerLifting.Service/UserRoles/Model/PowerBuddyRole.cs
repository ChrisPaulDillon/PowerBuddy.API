using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Service.UserRoles.Model
{
    public class PowerBuddyRole : IdentityRole<string>
    {
        public string PowerBuddyRoleId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
            //public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
