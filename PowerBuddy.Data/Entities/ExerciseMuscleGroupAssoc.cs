namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// Represents the association of musclegroups to a given exercise
    /// </summary>
    public partial class ExerciseMuscleGroupAssoc
    {
        public int ExerciseMuscleGroupAssocId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public bool IsPrimary { get; set; }
        public int ExerciseId { get; set; }
    }
}