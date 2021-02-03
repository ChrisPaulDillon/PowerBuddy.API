using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Authentication
{
    public class UpdatePasswordCommand : IRequest<OneOf<bool, UserNotFound, InvalidCredentials>>
    {
        public ChangePasswordInputGuiDTO ChangePasswordInput { get; }
        public string UserId { get; }

        public UpdatePasswordCommand(ChangePasswordInputGuiDTO changePasswordInput, string userId)
        {
            ChangePasswordInput = changePasswordInput;
            UserId = userId;
        }
    }

    public class UpdatePasswordQueryValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordQueryValidator()
        {
            RuleFor(x => x.ChangePasswordInput.OldPassword).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ChangePasswordInput.NewPassword).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, OneOf<bool, UserNotFound, InvalidCredentials>>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public UpdatePasswordCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<OneOf<bool, UserNotFound, InvalidCredentials>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var hasCorrectPassword =
                await _userManager.CheckPasswordAsync(user, request.ChangePasswordInput.OldPassword);

            if (!hasCorrectPassword)
            {
                return new InvalidCredentials();
            }

            var result = await _userManager.ChangePasswordAsync(user, request.ChangePasswordInput.OldPassword,
                request.ChangePasswordInput.NewPassword);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
