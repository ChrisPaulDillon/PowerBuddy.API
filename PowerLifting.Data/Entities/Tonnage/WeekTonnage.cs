namespace PowerLifting.Data.Entities.Tonnage
{
    public class WeekTonnage
    {
        public int WeekTonnageId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal TotalTonnage { get; set; }
    }
}
