using System.Collections.Generic;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.DTO
{
    public class TemplateExerciseDTO
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public double? Percentage { get; set; }
        public int NoOfSets { get; set; }

        public virtual ExerciseDTO Exercise { get; set; }
        public virtual ICollection<TemplateRepScheme> TemplateRepSchemes { get; set; }
    }
}