using System.Collections.Generic;
using PowerLifting.Service.TemplateDays.Model;

namespace PowerLifting.Service.TemplateWeek.Model
{
    public class TemplateWeek
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNumber { get; set; }
        public IEnumerable<TemplateDay> TemplateDays { get; set;}
    }
}
