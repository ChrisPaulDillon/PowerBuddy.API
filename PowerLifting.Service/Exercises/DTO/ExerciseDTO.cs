using PowerLifting.Service.Exercises.Model;

namespace Powerlifting.Service.Exercises.DTO
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? ExerciseCategoryId { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
    }
}
