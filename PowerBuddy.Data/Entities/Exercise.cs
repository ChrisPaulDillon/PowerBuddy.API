namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public partial class Exercise
    {
        public int ExerciseId { get; set; }
        public int? ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public bool IsApproved { get; set; } = true;
        public string AdminApprover { get; set; }
        public bool IsMainExercise { get; set; }
    }
}