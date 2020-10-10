using System.Collections.Generic;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.Entities
{
    public partial class TemplateExercise
    {
        public virtual Entities.Exercise Exercise { get; set; }
        public virtual IEnumerable<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}
