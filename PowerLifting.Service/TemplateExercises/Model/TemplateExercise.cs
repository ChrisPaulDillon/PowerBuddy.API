﻿using System.Collections.Generic;
using PowerLifting.Services.TemplateRepSchemes.Model;

namespace Powerlifting.Services.TemplateExercises.Model
{
    /// <summary>
    /// TemplateExercise reprents on a fixed program template, a given exercise, its set, rep and percentage scemema
    /// </summary>
    public class TemplateExercise
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateProgramId { get; set; }
        public string ExerciseName { get; set; }
        public double? Percentage { get; set; }
        public int WeekNumber { get; set; }
        public int DayNumber { get; set; }
        public int NoOfSets { get; set; }
        public virtual ICollection<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}