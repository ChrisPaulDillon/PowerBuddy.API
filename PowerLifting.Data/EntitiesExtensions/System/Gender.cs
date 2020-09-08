using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Data.Entities.System
{
    public partial class Gender
    {
        public IEnumerable<User> Users { get; set; }
    }
}
