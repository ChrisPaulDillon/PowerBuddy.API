using System.Collections.Generic;
using PowerBuddy.Data.Dtos.LiftingStats;

namespace PowerBuddy.Data.Dtos.Users
{
    public class PublicUserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal BodyWeight { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
        public int MemberStatusId { get; set; }
        public string Gender { get; set; }
        public string LiftingLevel { get; set; }
        public IEnumerable<LiftFeedDto> LiftFeed { get; set; }
        public int PersonalBestCount { get; set; }
        public int WorkoutDayCount { get; set; }
    }
}
