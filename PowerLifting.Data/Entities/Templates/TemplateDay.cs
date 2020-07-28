using System.Collections.Generic;

namespace PowerLifting.Data.Entities.Templates
{
    public class TemplateDay
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int DayNo { get; set; }
        public virtual IEnumerable<TemplateExercise> TemplateExercises { get; set; }
    }
}