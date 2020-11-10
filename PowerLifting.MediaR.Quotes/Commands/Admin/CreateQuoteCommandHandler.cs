﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediaR.Quotes.Commands.Admin
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

    public class CreateQuoteCommandHandler : IRequestHandler<RequestQuoteCommand, QuoteDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuoteDTO> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin) throw new UnauthorisedUserException();

            var quoteEntity = _mapper.Map<Quote>(request.QuoteDTO); //TODO validate request
            _context.Quote.Add(quoteEntity);

            await _context.SaveChangesAsync(cancellationToken);
            return request.QuoteDTO;
        }
    }
}