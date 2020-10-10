using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.MediaR.Quotes.Command.Account;

namespace PowerLifting.MediaR.Quotes.CommandHandler.Account
{
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
