using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.Entities.Templates
{
    public partial class TemplateWeek
    {
        public virtual IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}
