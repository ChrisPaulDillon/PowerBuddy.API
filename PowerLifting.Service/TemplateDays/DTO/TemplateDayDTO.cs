using System;
using System.Collections.Generic;
using Powerlifting.Service.TemplateExercises.DTO;

namespace PowerLifting.Service.TemplateDays.DTO
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
