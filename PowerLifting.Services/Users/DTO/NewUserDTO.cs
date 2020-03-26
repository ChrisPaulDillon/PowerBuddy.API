using System;
using Powerlifting.Service.LiftingStats.DTO;

namespace PowerLifting.Services.Users.DTO
{
    public class NewUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
    }
}
