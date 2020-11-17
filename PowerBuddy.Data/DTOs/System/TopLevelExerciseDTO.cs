namespace PowerBuddy.Data.DTOs.System
{
    /// <summary>
    /// Used to display exercises at a glance within a list
    /// </summary>
    public class TopLevelExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? ExerciseTypeId { get; set; }
    }
}