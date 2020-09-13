using System.Collections.Generic;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.Data.DTOs.Account
{
    public class PublicUserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal BodyWeight { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
        public int MemberStatusId { get; set; }
        public string Gender { get; set; }
        public string LiftingLevel { get; set; }
        public IEnumerable<LiftFeedDTO> LiftFeed { get; set; }
    }
}
