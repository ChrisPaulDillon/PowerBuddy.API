using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateDay
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public ICollection<TemplateExercise> TemplateExercises { get; set; }
    }
}