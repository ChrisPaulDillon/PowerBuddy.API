using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Models.System;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Quotes
{
    public class DeleteQuoteCommand : IRequest<OneOf<bool, UserNotFound, QuoteNotFound>>
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
            RuleFor(x => x.QuoteId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommand, OneOf<bool, UserNotFound, QuoteNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public DeleteQuoteCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, UserNotFound, QuoteNotFound>> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin)
            {
                return new UserNotFound();
            }

            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == request.QuoteId).AsNoTracking().AnyAsync(cancellationToken: cancellationToken);

            if (!doesQuoteExist)
            {
                return new QuoteNotFound();
            }

            _context.Quote.Remove(new Quote() { QuoteId = request.QuoteId });

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
