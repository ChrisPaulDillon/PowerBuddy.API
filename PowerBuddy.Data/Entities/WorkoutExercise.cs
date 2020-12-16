namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutExercise
    {
        public int WorkoutExerciseId { get; set; }
        public int WorkoutDayId { get; set; }
        public int? WorkoutTemplateId { get; set; }
        public int WorkoutExerciseTonnageId { get; set; }
        public int ExerciseId { get; set; }
        public string Comment { get; set; }
    }
}
