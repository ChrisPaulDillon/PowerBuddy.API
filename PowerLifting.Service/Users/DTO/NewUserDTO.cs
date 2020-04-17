using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.Service.Users.DTO
{
    public class NewUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
    }
}