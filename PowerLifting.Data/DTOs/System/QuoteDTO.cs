using System;
namespace PowerLifting.Entity.System.Quotes.DTOs
{
    public class QuoteDTO
    {
        public int QuoteId { get; set; }
        public string QuoteStr { get; set; }
        public string Author { get; set; }
        public short Year { get; set; }
        public bool Active { get; set; }
    }
}
