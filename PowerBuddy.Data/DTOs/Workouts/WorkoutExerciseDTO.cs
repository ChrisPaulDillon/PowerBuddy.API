using System.Collections.Generic;
using PowerBuddy.Data.DTOs.ProgramLogs;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutExerciseDTO
    {
        public int ProgramLogExerciseId { get; set; }
        public int WorkoutTemplateId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string ExerciseName { get; set; }
        public virtual IEnumerable<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; }
    }
}
