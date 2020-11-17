using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateDayDTO
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int DayNo { get; set; }
        public IEnumerable<TemplateExerciseDTO> TemplateExercises { get; set; }
    }
}