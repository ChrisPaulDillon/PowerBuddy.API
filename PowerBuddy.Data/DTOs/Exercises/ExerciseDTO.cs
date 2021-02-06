using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Exercises
{
    public class ExerciseDto
    {
        public int ExerciseId { get; set; }
        public int? ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseTypeName { get; set; }
        public bool IsApproved { get; set; }
        public string AdminApprover { get; set; }
        public bool IsMainExercise { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssocDto> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSportDto> ExerciseSports { get; set; }
    }
}