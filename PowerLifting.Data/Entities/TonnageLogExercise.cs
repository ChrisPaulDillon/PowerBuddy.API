namespace PowerLifting.Data.Entities
{
    public partial class TonnageLogExercise
    {
        public int TonnageLogExerciseId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ExerciseId { get; set; }
        public decimal TotalTonnage { get; set; }
    }
}