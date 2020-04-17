using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateWeek
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNumber { get; set; }
        public IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}