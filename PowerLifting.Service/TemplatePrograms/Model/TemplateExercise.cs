﻿using System.Collections.Generic;

namespace PowerLifting.Service.TemplatePrograms.Model
{
    /// <summary>
    ///     TemplateExercise represents on a fixed program template, a given exercise,
    ///     its set, rep and percentage schema
    /// </summary>
    public class TemplateExercise
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public string ExerciseName { get; set; }
        public double? Percentage { get; set; }
        public int NoOfSets { get; set; }
        public virtual ICollection<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}