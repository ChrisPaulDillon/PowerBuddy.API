using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class MemberStatus
    {
        public IEnumerable<User> Users { get; set; }
    }
}
