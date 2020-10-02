using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.Entities.Account
{
    public partial class User
    {
        public Gender Gender { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public IEnumerable<LiftingStatAudit> LiftingStatAudit { get; set; }
        public UserSetting UserSetting { get; set; }
    }
}
