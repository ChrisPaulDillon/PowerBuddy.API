using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Systems.Repository
{
    public interface IQuoteRepository
    {

        Task<IEnumerable<QuoteDTO>> GetAllQuotes();

        Task<QuoteDTO> GetQuoteById(int quoteId);

        Task<Quote> CreateQuote(QuoteDTO quote);

        Task<bool> UpdateQuote(QuoteDTO quote);

        Task<bool> DeleteQuote(QuoteDTO quote);

        Task<bool> DoesQuoteExist(int id);
    }
}