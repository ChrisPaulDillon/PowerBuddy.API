namespace PowerLifting.Data.Entities
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteStr { get; set; }
        public string Author { get; set; }
        public short? Year { get; set; }
        public string QuoteCategory { get; set; }
        public bool Active { get; set; }
        public bool IsApproved { get; set; }
        public string UserId { get; set; }
    }
}
