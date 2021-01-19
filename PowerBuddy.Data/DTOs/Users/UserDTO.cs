namespace PowerBuddy.Data.DTOs.Users
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal BodyWeight { get; set; }
        public string LiftingLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LiftingStatId { get; set; }
        public string SportType { get; set; }
        public bool QuotesEnabled { get; set; } = true;
        public bool FirstVisit { get; set; }
        public UserSettingDTO UserSetting { get; set; }
        public string Gender { get; set; }
        public int MemberStatusId { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}