using System.Collections.Generic;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Entities
{
    public partial class TonnageLog
    {
        public IEnumerable<TonnageWeek> TonnageWeeks { get; set; }
        public IEnumerable<TonnageDay> TonnageDays { get; set; }
    }
}
