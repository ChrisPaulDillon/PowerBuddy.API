namespace PowerLifting.Data.DTOs.Exercises
{
    public class ExerciseMuscleGroupAssocDTO
    {
        public int ExerciseMuscleGroupAssocId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public bool IsPrimary { get; set; }
        public int ExerciseId { get; set; }
    }
}