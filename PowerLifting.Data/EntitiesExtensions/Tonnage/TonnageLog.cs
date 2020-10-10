using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.Tonnage
{
    public partial class TonnageLog
    {
        public IEnumerable<TonnageWeek> TonnageWeeks { get; set; }
        public IEnumerable<TonnageDay> TonnageDays { get; set; }
    }
}
