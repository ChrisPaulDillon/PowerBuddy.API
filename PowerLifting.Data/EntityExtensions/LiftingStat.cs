using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class LiftingStat
    {
        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<LiftingStatAudit> LiftingStatAudits { get; set; }
    }
}
