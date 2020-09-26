using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Data.Entities.Exercises
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public bool IsApproved { get; set; } = true;
        public string AdminApprover { get; set; }
        public bool IsMainExercise { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssoc> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSport> ExerciseSports { get; set; }
    }
}