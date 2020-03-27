using System.Collections.Generic;
using Powerlifting.Services.IndividualSets.DTO;

namespace Powerlifting.Service.ProgramExercises.DTO
{
    public class ProgramExerciseDTO
    {
        public int ProgramExerciseId { get; set; }
        public int ProgramTemplateId { get; set; }
        public string ExerciseName { get; set; }
        public double Percentage { get; set; }
        public int WeekNumber { get; set; }
        public int DayNumber { get; set; }
        public int NoOfSets { get; set; }
        public virtual ICollection<MarkupIndividualSetDTO> IndividualSets { get; set; }
    }
}
