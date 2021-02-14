using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateProgram
    {
        public IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}
