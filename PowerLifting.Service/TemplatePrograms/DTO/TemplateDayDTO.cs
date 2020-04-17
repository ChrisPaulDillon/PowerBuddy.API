using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.DTO
{
    public class TemplateDayDTO
    {
        public int TemplateDayId { get; set; }
        public int TemplateId { get; set; }
        public int TemplateWeekId { get; set; }
        public string DayOfWeek { get; set; }
        public IEnumerable<TemplateExerciseDTO> TemplateExercises { get; set; }
    }
}