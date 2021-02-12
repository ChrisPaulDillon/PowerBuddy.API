using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Authentication
{
    public class AcceptEmailConfirmationCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public string UserId { get; }
        public string Token { get; }

        public AcceptEmailConfirmationCommand(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }

    public class AcceptEmailCommandValidator : AbstractValidator<AcceptEmailConfirmationCommand>
    {
        public AcceptEmailCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class AcceptEmailConfirmationCommandHandler : IRequestHandler<AcceptEmailConfirmationCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public AcceptEmailConfirmationCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(AcceptEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            return result.Succeeded;
        }
    }
}