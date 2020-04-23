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
        public string TemplateType { get; set; } //incremental, percentage based

        public virtual ICollection<TemplateWeek> TemplateWeeks { get; set; }
        public virtual ICollection<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
    }
}