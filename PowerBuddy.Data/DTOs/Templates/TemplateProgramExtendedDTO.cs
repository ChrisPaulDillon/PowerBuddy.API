using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateProgramExtendedDto
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int NoOfDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //incremental, percentage based
        public string WeightProgressionType { get; set; } //incremental, percentage based
        public int ActiveUsersCount { get; set; }
        public virtual IEnumerable<TemplateDayDto> TemplateDays { get; set; }
        public IEnumerable<TemplateExerciseCollectionDto> TemplateExerciseCollection { get; set; }
    }
}
