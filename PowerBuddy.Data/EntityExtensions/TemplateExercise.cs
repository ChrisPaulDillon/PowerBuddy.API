using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateExercise
    {
        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}
