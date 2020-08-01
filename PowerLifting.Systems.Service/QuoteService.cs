using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;
using PowerLifting.Data.Exceptions.System;
using PowerLifting.Persistence;

namespace PowerLifting.Systems.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public QuoteService(PowerLiftingContext context, IMapper mapper)
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
            var quote = await _context.Set<Quote>()
                .Where(c => c.QuoteId == quoteId)
                .ProjectTo<QuoteDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (quote == null)
            {
                throw new QuoteNotFoundException();
            }

            return quote;
        }

        public async Task<QuoteDTO> CreateQuote(QuoteDTO quoteDTO)
        {
            var quoteEntity = _mapper.Map<Quote>(quoteDTO);
            _context.Add(quoteEntity);

            await _context.SaveChangesAsync();
            return quoteDTO;
        }

        public async Task<bool> UpdateQuote(QuoteDTO quoteDTO)
        {
            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == quoteDTO.QuoteId).AsNoTracking().AnyAsync();

            if (!doesQuoteExist) throw new QuoteNotFoundException();

            var quote = _mapper.Map<Quote>(quoteDTO);
            _context.Update(quote);

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> DeleteQuote(int quoteId)
        {
            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == quoteId).AsNoTracking().AnyAsync();

            if (!doesQuoteExist) throw new QuoteNotFoundException();

            _context.Remove(new Quote() { QuoteId = quoteId });

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }
    }
}