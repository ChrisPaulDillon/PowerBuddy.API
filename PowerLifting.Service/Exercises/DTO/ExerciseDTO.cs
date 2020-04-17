using System.Collections.Generic;
using PowerLifting.Service.Exercises.Model;

namespace PowerLifting.Service.Exercises.DTO
{
    /// <summary>
    ///     Used for a lookups table for each individual lift
    /// </summary>
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual ICollection<ExerciseMuscleGroupDTO> ExerciseMuscleGroups { get; set; }
    }
}