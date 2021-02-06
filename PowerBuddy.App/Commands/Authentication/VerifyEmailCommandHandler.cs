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

namespace PowerBuddy.App.Commands.Authentication
{
    public class VerifyEmailCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public string UserId { get; }
        public string Token { get; }

        public VerifyEmailCommand(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }

    public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
    {
        public VerifyEmailCommandValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public VerifyEmailCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return new UserNotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}