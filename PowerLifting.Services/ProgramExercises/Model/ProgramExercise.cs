using System.Collections.Generic;
using Powerlifting.Services.IndividualSets.DTO;

namespace Powerlifting.Service.ProgramExercises.Model
{
    public class ProgramExercise
    {
        public int ProgramExerciseId { get; set; }
        public int ProgramTypeId { get; set; }
        public int ExerciseId { get; set; }
        public int WeekNumber { get; set; }
        public string DayOfWeek { get; set; }
        public virtual ICollection<IndividualSetDTO> IndividualSets { get; set; }
    }
}
