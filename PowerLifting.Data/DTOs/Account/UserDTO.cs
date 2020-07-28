namespace PowerLifting.Data.DTOs.Account
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int LiftingStatId { get; set; }
        public virtual LiftingStatDTO LiftingStats { get; set; }
        public virtual UserSettingDTO UserSetting { get; set; }
    }
}