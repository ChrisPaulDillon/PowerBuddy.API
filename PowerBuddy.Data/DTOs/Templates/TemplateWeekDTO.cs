using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateWeekDTO
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNo { get; set; }
        public virtual IEnumerable<TemplateDayDTO> TemplateDays { get; set; }
    }
}