using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class Gender
    {
        public IEnumerable<User> Users { get; set; }
    }
}
