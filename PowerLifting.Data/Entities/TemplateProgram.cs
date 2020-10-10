namespace PowerLifting.Data.Entities
{
    public partial class TemplateProgram
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int NoOfDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //block training, autoregulation?
        public string WeightProgressionType { get; set; } //incremental, percentage based
        public bool IsPublished { get; set; }
    }
}