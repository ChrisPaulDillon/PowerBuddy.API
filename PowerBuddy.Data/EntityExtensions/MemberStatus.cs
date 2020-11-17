using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class MemberStatus
    {
        public IEnumerable<User> Users { get; set; }
    }
}
