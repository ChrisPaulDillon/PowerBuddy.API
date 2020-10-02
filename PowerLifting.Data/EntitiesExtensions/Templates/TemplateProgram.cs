using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.Entities.Templates
{
    public partial class TemplateProgram
    {
        public virtual IEnumerable<TemplateWeek> TemplateWeeks { get; set; }
        public virtual IEnumerable<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
    }
}
