using System.Collections.Generic;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.DTOs.Exercises
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int? ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public bool IsMainExercise { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssocDTO> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSportDTO> ExerciseSports { get; set; }
    }
}