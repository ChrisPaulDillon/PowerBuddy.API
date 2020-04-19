using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateProgram
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int MaxLiftDaysPerWeek { get; set; }
        public ICollection<TemplateWeek> TemplateWeeks { get; set; }
    }
}