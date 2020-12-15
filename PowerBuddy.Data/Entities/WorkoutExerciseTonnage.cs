namespace PowerBuddy.Data.Entities
{
    public class WorkoutExerciseTonnage
    {
        public int WorkoutExerciseTonnageId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
