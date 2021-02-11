using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.System;
using PowerBuddy.Data.Entities;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Quotes
{
    public class RequestQuoteCommand : IRequest<QuoteDto>
    {
        public QuoteDto QuoteDto { get; }
        public string UserId { get; }

        public RequestQuoteCommand(QuoteDto quoteDto, string userId)
        {
            QuoteDto = quoteDto;
            UserId = userId;
        }
    }

    public class RequestQuoteCommandValidator : AbstractValidator<RequestQuoteCommand>
    {
        public RequestQuoteCommandValidator()
        {
            RuleFor(x => x.QuoteDto).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class RequestQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, QuoteDto>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public RequestQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuoteDto> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
        {
            var quoteEntity = _mapper.Map<Quote>(request.QuoteDto); //TODO validate request
            await _context.Quote.AddAsync(quoteEntity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return request.QuoteDto;
        }
    }
}
