using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateDayDto
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int DayNo { get; set; }
        public IEnumerable<TemplateExerciseDto> TemplateExercises { get; set; }
    }
}