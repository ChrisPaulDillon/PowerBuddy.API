using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.Templates
{
    public partial class TemplateDay
    {
        public virtual IEnumerable<TemplateExercise> TemplateExercises { get; set; }
    }
}
