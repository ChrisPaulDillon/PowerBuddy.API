namespace PowerBuddy.Data.Dtos.Exercises
{
    public class ExerciseMuscleGroupAssocDto
    {
        public int ExerciseMuscleGroupAssocId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public bool IsPrimary { get; set; }
        public int ExerciseId { get; set; }
    }
}