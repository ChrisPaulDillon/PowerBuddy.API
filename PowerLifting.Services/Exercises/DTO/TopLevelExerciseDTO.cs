using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Powerlifting.Services.ExerciseCategories.Model;

namespace Powerlifting.Service.Exercises.DTO
{
    /// <summary>
    /// Used to display exercises at a glance within a list
    /// </summary>
    public class TopLevelExerciseDTO
    {
        public int ExerciseId { get; set; }
        public String ExerciseName { get; set; }
        public int? ExerciseCategoryId { get; set; }
        public virtual ExerciseCategory ExerciseCategory { get; set; }
    }
}
