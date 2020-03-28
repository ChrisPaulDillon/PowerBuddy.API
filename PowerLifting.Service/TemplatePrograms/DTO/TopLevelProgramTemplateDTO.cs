namespace Powerlifting.Services.TemplatePrograms.DTO
{
    //Used for showing all program templates as a general overview
    public class TopLevelTemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
    }
}
