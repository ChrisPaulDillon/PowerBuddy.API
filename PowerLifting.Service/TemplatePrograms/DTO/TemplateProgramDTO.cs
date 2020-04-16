using System.Collections.Generic;
using PowerLifting.Service.TemplateWeeks.DTO;

namespace Powerlifting.Service.TemplatePrograms.DTO
{
    public class TemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public ICollection<TemplateWeekDTO> TemplateWeeks { get; set; }
    }
}
