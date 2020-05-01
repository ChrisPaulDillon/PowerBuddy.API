namespace PowerLifting.Service.TemplatePrograms.Model
{
    public class TemplateRepScheme
    {
        public int TemplateRepSchemeId { get; set; }
        public int TemplateExerciseId { get; set; } //Is this set for a fixed program or a user?
        public double? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; } //minimum number of reps to be performed
        public double WeightLifted { get; set; }
        public bool IsBackOffSet { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
    }
}