using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class ProgramLogWeek
    {
        public IEnumerable<ProgramLogDay> ProgramLogDays { get; set; }
    }
}
