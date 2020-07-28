namespace PowerLifting.Data.DTOs.System
{
    public class ExerciseMuscleGroupDTO
    {
        public int ExerciseMuscleGroupId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public bool IsPrimary { get; set; }
        public int ExerciseId { get; set; }
    }
}