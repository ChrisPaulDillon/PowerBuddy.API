using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateWeekDTO
    {
        public int TemplateWeekId { get; set; }
        public int TemplateProgramId { get; set; }
        public int WeekNo { get; set; }
        public virtual IEnumerable<TemplateDayDTO> TemplateDays { get; set; }
    }
}