using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Commands.Emails.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.App.Commands.Emails
{
    public class SendPasswordResetCommand : IRequest<OneOf<Unit, UserNotFound>>
    {
        public string EmailAddress { get; }

        public SendPasswordResetCommand(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }

    public class SendPasswordResetCommandValidator : AbstractValidator<SendPasswordResetCommand>
    {
        public SendPasswordResetCommandValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class SendPasswordResetCommandHandler : IRequestHandler<SendPasswordResetCommand, OneOf<Unit, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IEmailAssistant _emailHelper;
        private readonly IEmailClient _emailClient;
        private readonly UserManager<User> _userManager;

        public SendPasswordResetCommandHandler(PowerLiftingContext context, IEmailAssistant emailHelper, IEmailClient emailClient, UserManager<User> userManager)
        {
            _context = context;
            _emailHelper = emailHelper;
            _emailClient = emailClient;
            _userManager = userManager;
        }

        public async Task<OneOf<Unit, UserNotFound>> Handle(SendPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .Where(x => x.NormalizedEmail.Equals(request.EmailAddress.ToUpper()))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"{_emailHelper.BaseUrl}/account/changepassword?userId={user.Id}&token={token}";

            var emailMessage = new EmailMessage(new List<string>() { user.Email }, "PowerBuddy - Reset Password", resetLink);

            await _emailClient.SendEmailAsync(emailMessage);

            return Unit.Value;
        }
    }
}