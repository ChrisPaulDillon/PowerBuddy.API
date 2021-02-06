namespace PowerBuddy.Data.Dtos.System
{
    /// <summary>
    /// Used to display exercises at a glance within a list
    /// </summary>
    public class TopLevelExerciseDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int? ExerciseTypeId { get; set; }
    }
}