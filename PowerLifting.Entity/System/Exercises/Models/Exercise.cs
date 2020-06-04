﻿using System.Collections.Generic;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.ExerciseTypes.Models;

namespace PowerLifting.Entity.System.Exercises.Models
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public bool IsProgrammable { get; set; } //Is this a main lift / can numbers be generated using this lift
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroup> ExerciseMuscleGroups { get; set; }
    }
}