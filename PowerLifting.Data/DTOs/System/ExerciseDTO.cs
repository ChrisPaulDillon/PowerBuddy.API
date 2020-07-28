using System.Collections.Generic;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Entity.System.ExerciseSports.DTOs;
using PowerLifting.Entity.System.ExerciseSports.Model;
using PowerLifting.Entity.System.ExerciseTypes.Models;

namespace PowerLifting.Entity.System.Exercises.DTOs
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupDTO> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSportDTO> ExerciseSports { get; set; }
    }
}