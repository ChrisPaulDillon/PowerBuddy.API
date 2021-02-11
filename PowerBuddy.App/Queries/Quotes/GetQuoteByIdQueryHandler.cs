using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.System;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.System;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.Quotes
{
    public class GetQuoteByIdQuery : IRequest<OneOf<QuoteDto, QuoteNotFound>>
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
            RuleFor(x => x.QuoteId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    internal class GetQuoteByIdQueryHandler : IRequestHandler<GetQuoteByIdQuery, OneOf<QuoteDto, QuoteNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetQuoteByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<QuoteDto, QuoteNotFound>> Handle(GetQuoteByIdQuery request, CancellationToken cancellationToken)
        {
            var quote = await _context.Set<Quote>()
                .Where(c => c.QuoteId == request.QuoteId)
                .ProjectTo<QuoteDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (quote == null)
            {
                return new QuoteNotFound();
            }

            return quote;
        }
    }
}
