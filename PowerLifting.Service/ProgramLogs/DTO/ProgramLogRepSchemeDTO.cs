namespace PowerLifting.Service.ProgramLogs.DTO
{
    public class ProgramLogRepSchemeDTO
    {
        public int ProgramLogRepSchemeId { get; set; }
        public int? ProgramLogExerciseId { get; set; }
        public double? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
        public string Comment { get; set; }
    }
}