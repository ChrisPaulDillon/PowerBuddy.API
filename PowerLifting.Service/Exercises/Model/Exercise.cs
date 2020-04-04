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
        public int ExerciseTypeId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
    }
}
