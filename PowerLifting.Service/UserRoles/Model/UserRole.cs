using System;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.UserRoles.Model
{
    public class UserRole : IdentityUserRole<string>
    {
        public string ApplicationUserRoleId { get; set; }
        public virtual User User { get; set; }
        public virtual PowerBuddyRole Role { get; set; }
    }
}
