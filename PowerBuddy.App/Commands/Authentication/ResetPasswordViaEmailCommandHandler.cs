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
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Authentication
{
    public class ResetPasswordViaEmailCommand : IRequest<OneOf<bool, UserNotFound>>
    {
	    public ResetPasswordTokenRequest ChangePasswordTokenRequest { get; }
        public string UserId { get; }
        
        public ResetPasswordViaEmailCommand(ResetPasswordTokenRequest changePasswordTokenRequest, string userId)
        {
	        ChangePasswordTokenRequest = changePasswordTokenRequest;
            UserId = userId;
        }
    }

    public class ResetPasswordViaEmailCommandValidator : AbstractValidator<ResetPasswordViaEmailCommand>
    {
        public ResetPasswordViaEmailCommandValidator()
        {
            RuleFor(x => x.ChangePasswordTokenRequest.Token).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.ChangePasswordTokenRequest.Password).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class ResetPasswordViaEmailCommandHandler : IRequestHandler<ResetPasswordViaEmailCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public ResetPasswordViaEmailCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(ResetPasswordViaEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var result = await _userManager.ResetPasswordAsync(user, request.ChangePasswordTokenRequest.Token, request.ChangePasswordTokenRequest.Password);

            return result.Succeeded;
        }
    }
}