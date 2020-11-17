using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateProgram
    {
        public virtual IEnumerable<TemplateWeek> TemplateWeeks { get; set; }
        public virtual IEnumerable<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
    }
}
