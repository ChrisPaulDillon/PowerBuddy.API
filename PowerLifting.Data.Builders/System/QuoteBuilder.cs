using System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.Builders.System
{
    public class QuoteBuilder
    {
        private readonly Random _random;
        private readonly Quote _quote;

        public QuoteBuilder(Random random = null)
        {
            _random = random ?? new Random();
            _quote = new Quote()
            {
                QuoteId = _random.Next(),
                QuoteStr = _random.Next().ToString(),
                Author = _random.Next().ToString(),
                Year = (short?)_random.Next(),
                QuoteCategory = _random.Next().ToString(),
                Active = true
            };
        }

        public Quote Build()
        {
            return _quote;
        }

        public QuoteBuilder WithQuoteId(int quoteId)
        {
            _quote.QuoteId = quoteId;
            return this;
        }

        public QuoteBuilder WithQuoteStr(string quoteStr)
        {
            _quote.QuoteStr = quoteStr;
            return this;
        }

        public QuoteBuilder WithAuthor(string author)
        {
            _quote.Author = author;
            return this;
        }

        public QuoteBuilder WithYear(short year)
        {
            _quote.Year = year;
            return this;
        }

        public QuoteBuilder WithQuoteCategory(string category)
        {
            _quote.QuoteCategory = category;
            return this;
        }
    }
}
