using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateDay
    {
        public virtual IEnumerable<TemplateExercise> TemplateExercises { get; set; }
    }
}
