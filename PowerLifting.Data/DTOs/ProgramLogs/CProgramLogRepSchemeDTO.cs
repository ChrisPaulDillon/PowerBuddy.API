namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class CProgramLogRepSchemeDTO
    {
        public int SetNo { get; set; }
        public int NoOfReps { get; set; }
        public decimal WeightLifted { get; set; }
        public decimal? Percentage { get; set; }
        public string Comment { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
    }
}