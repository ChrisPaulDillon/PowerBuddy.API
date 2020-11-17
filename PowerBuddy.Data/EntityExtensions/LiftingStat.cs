using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class LiftingStat
    {
        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<LiftingStatAudit> LiftingStatAudits { get; set; }
    }
}
