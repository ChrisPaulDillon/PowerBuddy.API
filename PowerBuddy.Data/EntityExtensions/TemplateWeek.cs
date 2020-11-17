using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateWeek
    {
        public virtual IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}
