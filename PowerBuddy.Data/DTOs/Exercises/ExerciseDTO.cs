using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Exercises
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int? ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseTypeName { get; set; }
        public bool IsApproved { get; set; }
        public string AdminApprover { get; set; }
        public bool IsMainExercise { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssocDTO> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSportDTO> ExerciseSports { get; set; }
    }
}