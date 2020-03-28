using System;
using Powerlifting.Services.ExerciseCategories.Model;

namespace Powerlifting.Service.Exercises.DTO
{
    /// <summary>
    /// Used to display exercises at a glance within a list
    /// </summary>
    public class TopLevelExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? ExerciseCategoryId { get; set; }
    }
}
