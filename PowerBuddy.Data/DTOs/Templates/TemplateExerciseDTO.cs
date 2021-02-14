using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Exercises;

namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateExerciseDto
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public string RepSchemeType { get; set; } //ramped, fixed
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }
        public string ExerciseName { get; set; }
        public virtual IEnumerable<TemplateRepSchemeDto> TemplateRepSchemes { get; set; }
    }
}