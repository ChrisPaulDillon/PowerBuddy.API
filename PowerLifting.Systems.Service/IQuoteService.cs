using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Systems.Service
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDTO>> GetAllQuotes();

        Task<QuoteDTO> GetQuoteById(int quoteId);

        Task<Quote> CreateQuote(QuoteDTO quote);
    }
}