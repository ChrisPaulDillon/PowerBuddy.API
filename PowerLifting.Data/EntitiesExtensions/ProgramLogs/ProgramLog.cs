using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public partial class ProgramLog
    {
        public IEnumerable<ProgramLogWeek> ProgramLogWeeks { get; set; }
        public virtual TemplateProgram TemplateProgram { get; set; }
    }
}
