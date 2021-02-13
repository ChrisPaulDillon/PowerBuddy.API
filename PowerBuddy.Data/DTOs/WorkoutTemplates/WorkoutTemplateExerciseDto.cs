using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.WorkoutTemplates
{
    public class WorkoutTemplateExerciseDto
    {
        public int WorkoutExerciseId { get; set; }
        public int WorkoutTemplateId { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public virtual IEnumerable<WorkoutTemplateSetDto> WorkoutSets { get; set; }
    }
}
