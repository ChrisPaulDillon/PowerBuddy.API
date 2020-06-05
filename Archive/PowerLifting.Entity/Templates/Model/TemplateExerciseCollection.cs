namespace PowerLifting.Service.TemplatePrograms.Model
{
    /// <summary>
    /// Used to collect all exercises associated with a given
    /// TemplateProgram
    /// </summary>
    public class TemplateExerciseCollection
    {
        public int TemplateExerciseCollectionId { get; set; }
        public int TemplateProgramId { get; set; }
        public int ExerciseId { get; set; }
    }
}
