using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.Entities.Templates
{
    public partial class TemplateExercise
    {
        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}
