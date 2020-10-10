using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class TemplateDay
    {
        public virtual IEnumerable<TemplateExercise> TemplateExercises { get; set; }
    }
}
