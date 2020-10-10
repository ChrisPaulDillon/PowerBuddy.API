using System.Collections.Generic;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Entities
{
    public partial class TemplateProgram
    {
        public virtual IEnumerable<TemplateWeek> TemplateWeeks { get; set; }
        public virtual IEnumerable<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
    }
}
