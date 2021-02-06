using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Users
{
    public class BanUserCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public string UserId { get; }
        public string AdminUserId { get; }

        public BanUserCommand(string userId, string adminUserId)
        {
            UserId = userId;
            AdminUserId = adminUserId;
        }
    }

    public class BanUserCommandValidator : AbstractValidator<BanUserCommand>
    {
        public BanUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.AdminUserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class BanUserCommandHandler : IRequestHandler<BanUserCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public BanUserCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(BanUserCommand request, CancellationToken cancellationToken)
        {
            var userToBan = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (userToBan == null)
            {
                return new UserNotFound();
            }

            var adminUser = await _context.User.Where(x => x.Id == request.AdminUserId && x.MemberStatusId >= 2).Select(x => x.UserName).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (string.IsNullOrEmpty(adminUser))
            {
                return new UserNotFound();
            }

            userToBan.IsBanned = true;
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}