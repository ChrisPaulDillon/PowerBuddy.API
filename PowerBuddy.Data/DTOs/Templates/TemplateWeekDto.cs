using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Templates;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateWeekDto
    {
        public int WeekNo { get; set; }
        public IEnumerable<TemplateDayDto> TemplateDays { get; set; }
    }
}
