using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Systems.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public QuoteRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDTO>> GetAllQuotes()
        {
            return await _context.Set<Quote>()
                .Where(x => x.Active)
                .ProjectTo<QuoteDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<QuoteDTO> GetQuoteById(int quoteId)
        {
            return await _context.Set<Quote>()
               .Where(c => c.QuoteId == quoteId)
               .ProjectTo<QuoteDTO>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<Quote> CreateQuote(QuoteDTO quoteDTO)
        {
            var quote = _mapper.Map<Quote>(quoteDTO);
            _context.Add(quote);

            await _context.SaveChangesAsync();
            return quote;
        }

        public async Task<bool> UpdateQuote(QuoteDTO quoteDTO)
        {
            var quote = _mapper.Map<Quote>(quoteDTO);
            _context.Update(quote);

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> DeleteQuote(QuoteDTO quoteDTO)
        {
            var quote = _mapper.Map<Quote>(quoteDTO);
            _context.Remove(quote);

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> DoesQuoteExist(int id)
        {
            return await _context.Set<Quote>()
                   .Where(x => x.QuoteId == id)
                   .AsNoTracking()
                   .AnyAsync();
        }
    }
}
