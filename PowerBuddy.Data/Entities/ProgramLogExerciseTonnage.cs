namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLogExerciseTonnage
    {
        public int ProgramLogExerciseTonnageId { get; set; }
        public int ProgramLogExerciseId { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
    }
}
