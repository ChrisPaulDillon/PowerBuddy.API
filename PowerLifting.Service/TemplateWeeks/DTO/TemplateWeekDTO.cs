using System;
using System.Collections.Generic;
using PowerLifting.Service.TemplateDays.DTO;

namespace PowerLifting.Service.TemplateWeeks.DTO
{
    public class TemplateWeekDTO
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNumber { get; set; }
        public IEnumerable<TemplateDayDTO> TemplateDays { get; set; }
    }
}
