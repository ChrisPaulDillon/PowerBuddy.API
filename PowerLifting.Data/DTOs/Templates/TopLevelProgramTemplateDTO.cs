namespace PowerLifting.Data.DTOs.Templates
{
    /// <summary>
    ///     Used for showing all program templates as a general overview
    /// </summary>
    public class TopLevelTemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
    }
}