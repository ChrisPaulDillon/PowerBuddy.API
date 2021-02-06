using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Data.Models.LiftingStats;

namespace PowerBuddy.App.Commands.LiftingStats
{
    public class DeleteLiftingStatAuditCommand : IRequest<OneOf<bool, LiftingStatNotFound, UserNotFound>>
    {
        public int LiftingStatAuditId { get; }
        public string UserId { get; }

        public DeleteLiftingStatAuditCommand(int liftingStatAuditId, string userId)
        {
            LiftingStatAuditId = liftingStatAuditId;
            UserId = userId;
        }
    }

    public class DeleteLiftingStatAuditCommandValidator : AbstractValidator<DeleteLiftingStatAuditCommand>
    {
        public DeleteLiftingStatAuditCommandValidator()
        {
            RuleFor(x => x.LiftingStatAuditId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class DeleteLiftingStatAuditCommandHandler : IRequestHandler<DeleteLiftingStatAuditCommand, OneOf<bool, LiftingStatNotFound, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public DeleteLiftingStatAuditCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, LiftingStatNotFound, UserNotFound>> Handle(DeleteLiftingStatAuditCommand request, CancellationToken cancellationToken)
        {
            var liftingStatAudit = await _context.LiftingStatAudit
                .FirstOrDefaultAsync(x => x.LiftingStatAuditId == request.LiftingStatAuditId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (liftingStatAudit == null)
            {
                return new LiftingStatNotFound();
            }

            if (liftingStatAudit.UserId != request.UserId)
            {
                return new UserNotFound();
            }

            _context.LiftingStatAudit.Remove(liftingStatAudit); 
            
            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
