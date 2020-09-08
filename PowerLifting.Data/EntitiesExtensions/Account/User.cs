using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.Entities.Account
{
    public partial class User
    {
        public Gender Gender { get; set; }
        public MemberStatus MemberStatus { get; set; }
    }
}
