using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.Quotes.DTOs;
using PowerLifting.Entity.System.Quotes.Models;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDTO>> GetAllQuotes();

        Task<QuoteDTO> GetQuoteById(int quoteId);

        Task<Quote> CreateQuote(QuoteDTO quote);
    }
}