using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLogWeek
    {
        public IEnumerable<ProgramLogDay> ProgramLogDays { get; set; }
    }
}
