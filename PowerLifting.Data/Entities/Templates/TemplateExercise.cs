using System.Collections.Generic;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.Entities.Templates
{
    /// <summary>
    /// TemplateExercise represents on a fixed program template, a given exercise,
    /// its set, rep and percentage schema
    /// </summary>
    public class TemplateExercise
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public string RepSchemeType { get; set; } //ramped, fixed
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual IEnumerable<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}