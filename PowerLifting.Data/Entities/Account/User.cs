using Microsoft.AspNetCore.Identity;

namespace PowerLifting.Data.Entities.Account
{
    public class User : IdentityUser
    {
        public int LiftingStatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LiftingLevel { get; set; }
        public string Gender { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsBanned { get; set; }
        public string SportType { get; set; }
        public bool FirstVisit { get; set; }
        public int Rights { get; set; }
        public UserSetting UserSetting { get; set; }
    }
}