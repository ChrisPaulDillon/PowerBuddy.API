using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateWeek
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNo { get; set; }
        public virtual ICollection<TemplateDay> TemplateDays { get; set; }
    }
}