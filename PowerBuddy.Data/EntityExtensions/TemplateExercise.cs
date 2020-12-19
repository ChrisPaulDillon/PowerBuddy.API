using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateExercise
    {
        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}
