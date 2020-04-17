using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateDay
    {
        public int TemplateDayId { get; set; }
        public int TemplateId { get; set; }
        public int TemplateWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public IEnumerable<TemplateExercise> TemplateExercises { get; set; }
    }
}