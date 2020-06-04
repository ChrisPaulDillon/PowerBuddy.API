using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Service.Users.DTO
{
    public class RegisterUserDTO : IdentityUser
    {
        public string Password { get; set; }
    }
}