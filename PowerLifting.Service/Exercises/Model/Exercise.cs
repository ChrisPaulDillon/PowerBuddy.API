using System.Collections.Generic;
using PowerLifting.Service.Exercises.Model;

namespace Powerlifting.Service.Exercises.Model
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseCategoryId { get; set; }
        public int ExerciseMuscleGroupId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual ICollection<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
    }
}
