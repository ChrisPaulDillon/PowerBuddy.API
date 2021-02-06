using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutTemplateExerciseDTO
    {
        public int WorkoutExerciseId { get; set; }
        public int WorkoutTemplateId { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int NoOfSets { get; set; }
        public virtual IEnumerable<WorkoutSetDto> WorkoutSets { get; set; }
    }
}
