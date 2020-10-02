namespace PowerLifting.Data.Entities.Tonnage
{
    public class LogTonnage
    {
        public int LogTonnageId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ExerciseId { get; set; }
        public decimal TotalTonnage { get; set; }
    }
}