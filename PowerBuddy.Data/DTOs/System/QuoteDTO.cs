namespace PowerBuddy.Data.Dtos.System
{
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public string QuoteStr { get; set; }
        public string Author { get; set; }
        public short? Year { get; set; }
        public string QuoteCategory { get; set; }
        public bool Active { get; set; }
    }
}
