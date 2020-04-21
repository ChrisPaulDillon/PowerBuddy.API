using System.Collections.Generic;
using PowerLifting.Service.Exercises.Model;

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
        public int ExerciseId { get; set; }
        public double? Percentage { get; set; }
        public int NoOfSets { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}