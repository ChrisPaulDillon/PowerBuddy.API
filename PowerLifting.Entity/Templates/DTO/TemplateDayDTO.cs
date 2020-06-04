using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.DTO
{
    public class TemplateDayDTO
    {
        public int TemplateDayId { get; set; }
        public int TemplateWeekId { get; set; }
        public int DayNo { get; set; }
        public ICollection<TemplateExerciseDTO> TemplateExercises { get; set; }
    }
}