using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.Quotes.DTOs;
using PowerLifting.Entity.System.Quotes.Models;

namespace PowerLifting.Systems.Contracts.Repositories
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