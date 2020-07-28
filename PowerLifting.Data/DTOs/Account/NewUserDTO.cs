namespace PowerLifting.Data.DTOs.Account
{
    public class NewUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
    }
}