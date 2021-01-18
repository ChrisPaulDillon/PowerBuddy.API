using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Users.Models;

namespace PowerBuddy.MediatR.Users.Commands
{

    namespace PowerBuddy.MediatR.Users.Querys
    {
        public class UpdatePasswordCommand : IRequest<bool>
        {
            public ChangePasswordInputGuiDTO ChangePasswordInput { get; }
            public string UserId { get; }

            public UpdatePasswordCommand(ChangePasswordInputGuiDTO changePasswordInput, string userId)
            {
                ChangePasswordInput = changePasswordInput;
                UserId = userId;
                new UpdatePasswordQueryValidator().ValidateAndThrow(this);
            }
        }

        internal class UpdatePasswordQueryValidator : AbstractValidator<UpdatePasswordCommand>
        {
            public UpdatePasswordQueryValidator()
            {
                RuleFor(x => x.ChangePasswordInput.OldPassword).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
                RuleFor(x => x.ChangePasswordInput.NewPassword).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
                RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            }
        }

        internal class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
        {
            private readonly PowerLiftingContext _context;
            private readonly UserManager<User> _userManager;

            public UpdatePasswordCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.User.Where(x => x.Id == request.UserId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if (user == null)
                {
                    throw new UserNotFoundException();
                }

                var hasCorrectPassword = await _userManager.CheckPasswordAsync(user, request.ChangePasswordInput.OldPassword);

                if (!hasCorrectPassword)
                {
                    throw new InvalidCredentialsException();
                }

                var result = await _userManager.ChangePasswordAsync(user, request.ChangePasswordInput.OldPassword, request.ChangePasswordInput.NewPassword);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;
            }
        }
    }
}