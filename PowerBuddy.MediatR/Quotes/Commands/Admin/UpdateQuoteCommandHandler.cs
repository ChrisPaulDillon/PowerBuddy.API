using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.System;

namespace PowerBuddy.MediatR.Quotes.Commands.Admin
{
    public class UpdateQuoteCommand : IRequest<bool>
    {
        public QuoteDTO QuoteDTO { get; }
        public string UserId { get; }
        public UpdateQuoteCommand(QuoteDTO quoteDTO, string userId)
        {
            QuoteDTO = quoteDTO;
            UserId = userId;
        }
    }

    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public UpdateQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin) throw new UnauthorisedUserException();

            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == request.QuoteDTO.QuoteId).AsNoTracking().AnyAsync(cancellationToken: cancellationToken);

            if (!doesQuoteExist) throw new QuoteNotFoundException();

            var quote = _mapper.Map<Quote>(request.QuoteDTO);
            _context.Quote.Update(quote);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
