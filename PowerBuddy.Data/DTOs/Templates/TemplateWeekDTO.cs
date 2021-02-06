using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateWeekDto
    {
        public int TemplateWeekId { get; set; }
        public int TemplateProgramId { get; set; }
        public int WeekNo { get; set; }
        public virtual IEnumerable<TemplateDayDto> TemplateDays { get; set; }
    }
}