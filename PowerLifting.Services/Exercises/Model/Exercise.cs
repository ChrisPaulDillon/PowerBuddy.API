using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Services.ExerciseCategories.Model;

namespace Powerlifting.Service.Exercises.Model
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public String ExerciseName { get; set; }
        public int? ExerciseCategoryId { get; set; }
        public virtual ExerciseCategory ExerciseCategory { get; set; }
    }
}
