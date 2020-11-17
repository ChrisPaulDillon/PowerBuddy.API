namespace PowerBuddy.Data.DTOs.System
{
    public class QuoteDTO
    {
        public int QuoteId { get; set; }
        public string QuoteStr { get; set; }
        public string Author { get; set; }
        public short? Year { get; set; }
        public string QuoteCategory { get; set; }
        public bool Active { get; set; }
    }
}
