using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class Gender
    {
        public IEnumerable<User> Users { get; set; }
    }
}
