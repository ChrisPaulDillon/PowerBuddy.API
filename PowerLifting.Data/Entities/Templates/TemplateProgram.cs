using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.Data.Entities.Templates
{
    public class TemplateProgram
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int NoOfDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //block training, autoregulation?
        public string WeightProgressionType { get; set; } //incremental, percentage based
        public bool IsPublished { get; set; }
        public virtual IEnumerable<TemplateWeek> TemplateWeeks { get; set; }
        public virtual IEnumerable<TemplateExerciseCollection> TemplateExerciseCollection { get; set; }
    }
}