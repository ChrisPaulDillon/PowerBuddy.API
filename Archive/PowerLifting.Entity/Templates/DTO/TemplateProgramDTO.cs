using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.DTO
{
    public class TemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int MaxLiftDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //incremental, percentage based
        public string WeightProgressionType { get; set; } //incremental, percentage based

        public virtual ICollection<TemplateWeekDTO> TemplateWeeks { get; set; }
    }
}