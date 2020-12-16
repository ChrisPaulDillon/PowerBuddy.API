namespace PowerBuddy.Data.Entities
{
    public class WorkoutExerciseAudit
    {
        public int WorkoutExerciseAuditId { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public int SelectedCount { get; set; }
    }
}
