namespace PowerLifting.Data.DTOs.Tonnage
{
    public class WeekTonnageDTO
    {
        public int WeekTonnageId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal TotalTonnage { get; set; }
    }
}