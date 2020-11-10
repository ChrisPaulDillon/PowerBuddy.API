using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.System;

namespace PowerLifting.MediaR.Quotes.Commands.Admin
{
    public class DeleteQuoteCommand : IRequest<bool>
    {
        public int QuoteId { get; }
        public string UserId { get; }
        public DeleteQuoteCommand(int quoteId, string userId)
        {
            QuoteId = quoteId;
            UserId = userId;
        }
    }

    public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin) throw new UnauthorisedUserException();

            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == request.QuoteId).AsNoTracking().AnyAsync(cancellationToken: cancellationToken);

            if (!doesQuoteExist) throw new QuoteNotFoundException();

            _context.Quote.Remove(new Quote() { QuoteId = request.QuoteId });

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
