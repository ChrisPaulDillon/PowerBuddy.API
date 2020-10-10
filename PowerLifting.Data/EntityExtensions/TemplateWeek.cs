using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class TemplateWeek
    {
        public virtual IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}
