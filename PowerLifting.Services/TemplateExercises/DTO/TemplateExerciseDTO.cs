using System.Collections.Generic;
using PowerLifting.Services.TemplateRepSchemes.DTO;

namespace Powerlifting.Service.TemplateExercises.DTO
{
    public class TemplateExerciseDTO
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateProgramId { get; set; }
        public string ExerciseName { get; set; }
        public double? Percentage { get; set; }
        public int WeekNumber { get; set; }
        public int DayNumber { get; set; }
        public int NoOfSets { get; set; }
        public virtual ICollection<TemplateRepSchemeDTO> TemplateRepSchemes { get; set; }
    }
}
