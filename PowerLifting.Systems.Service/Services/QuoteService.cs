using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.Systems.Service.Exceptions;

namespace PowerLifting.Systems.Service.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;

        public QuoteService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDTO>> GetAllQuotes()
        {
            return await _repo.Quote.GetAllQuotes();
        }

        public async Task<QuoteDTO> GetQuoteById(int quoteId)
        {
            return await _repo.Quote.GetQuoteById(quoteId);
        }

        public async Task<Quote> CreateQuote(QuoteDTO quote)
        {
            var quoteEntity = await _repo.Quote.GetQuoteById(quote.QuoteId);
            if (quoteEntity == null) throw new QuoteNotFoundException();

            return await _repo.Quote.CreateQuote(quote);
        }
    }
}