using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Quotes.Commands
{
    public class RequestQuoteCommand : IRequest<QuoteDTO>
    {
        public QuoteDTO QuoteDTO { get; }
        public string UserId { get; }
        public RequestQuoteCommand(QuoteDTO quoteDTO, string userId)
        {
            QuoteDTO = quoteDTO;
            UserId = userId;
        }
    }
    public class RequestQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, QuoteDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public RequestQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuoteDTO> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
        {
            var quoteEntity = _mapper.Map<Quote>(request.QuoteDTO); //TODO validate request
            _context.Quote.Add(quoteEntity);

            await _context.SaveChangesAsync(cancellationToken);
            return request.QuoteDTO;
        }
    }
}
