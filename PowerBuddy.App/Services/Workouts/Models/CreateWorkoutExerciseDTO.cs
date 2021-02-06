namespace PowerBuddy.App.Services.Workouts.Models
{
    public class CreateWorkoutExerciseDto
    {
        public int WorkoutDayId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
