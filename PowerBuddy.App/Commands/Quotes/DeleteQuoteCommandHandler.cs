using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.System;

namespace PowerBuddy.App.Commands.Quotes
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
    public class DeleteQuoteCommandValidator : AbstractValidator<DeleteQuoteCommand>
    {
        public DeleteQuoteCommandValidator()
        {
            RuleFor(x => x.QuoteId).GreaterThan(0).WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
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

            if (!isUserAdmin) throw new UserNotFoundException();

            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == request.QuoteId).AsNoTracking().AnyAsync(cancellationToken: cancellationToken);

            if (!doesQuoteExist) throw new QuoteNotFoundException();

            _context.Quote.Remove(new Quote() { QuoteId = request.QuoteId });

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
