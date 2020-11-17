using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Entities
{
    public partial class User
    {
        public Gender Gender { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public IEnumerable<LiftingStatAudit> LiftingStatAudit { get; set; }
        public UserSetting UserSetting { get; set; }
        public FriendRequest FriendRequestTo { get; set; }
        public FriendRequest FriendRequestFrom { get; set; }
    }
}
