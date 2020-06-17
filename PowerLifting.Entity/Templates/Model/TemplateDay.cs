using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateDay
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int DayNo { get; set; }
        public virtual ICollection<TemplateExercise> TemplateExercises { get; set; }
    }
}