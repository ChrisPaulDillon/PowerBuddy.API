using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.System;

namespace PowerBuddy.App.Queries.Quotes
{
    public class GetQuoteByIdQuery : IRequest<QuoteDTO>
    {
        public int QuoteId { get; }
        public GetQuoteByIdQuery(int quoteId)
        {
            QuoteId = quoteId;
        }
    }

    public class GetQuoteByIdQueryValidator : AbstractValidator<GetQuoteByIdQuery>
    {
        public GetQuoteByIdQueryValidator()
        {
            RuleFor(x => x.QuoteId).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetQuoteByIdQueryHandler : IRequestHandler<GetQuoteByIdQuery, QuoteDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetQuoteByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuoteDTO> Handle(GetQuoteByIdQuery request, CancellationToken cancellationToken)
        {
            var quote = await _context.Set<Quote>()
                .Where(c => c.QuoteId == request.QuoteId)
                .ProjectTo<QuoteDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (quote == null)
            {
                throw new QuoteNotFoundException();
            }

            return quote;
        }
    }
}
