using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLogWeek
    {
        public ProgramLog ProgramLog { get; set; }
        public IEnumerable<ProgramLogDay> ProgramLogDays { get; set; }
    }
}
