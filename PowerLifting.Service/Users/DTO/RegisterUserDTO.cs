using System;
using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Services.Users.DTO
{
    public class RegisterUserDTO : IdentityUser
    {
        public int LiftingStatId { get; set; }
    }
}
