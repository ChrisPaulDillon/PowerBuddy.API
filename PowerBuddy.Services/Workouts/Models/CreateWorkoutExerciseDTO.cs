namespace PowerBuddy.Services.Workouts.Models
{
    public class CreateWorkoutExerciseDTO
    {
        public int WorkoutDayId { get; set; }
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
