﻿namespace PowerLifting.Data.Entities.System
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteStr { get; set; }
        public string Author { get; set; }
        public short Year { get; set; }
        public bool Active { get; set; }
    }
}
