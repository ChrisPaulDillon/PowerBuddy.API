using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLog
    {
        public IEnumerable<ProgramLogWeek> ProgramLogWeeks { get; set; }
        public virtual TemplateProgram TemplateProgram { get; set; }
    }
}
