using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class User
    {
        public Gender Gender { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public IEnumerable<LiftingStatAudit> LiftingStatAudit { get; set; }
        public UserSetting UserSetting { get; set; }
        public IEnumerable<WorkoutDay> WorkoutDays { get; set; }
    }
}
