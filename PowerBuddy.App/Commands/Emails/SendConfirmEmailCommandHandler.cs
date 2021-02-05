using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.Emails.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.App.Commands.Emails
{
    public class SendConfirmEmailCommand : IRequest<Unit>
    {
        public string UserId { get; }

        public SendConfirmEmailCommand(string userId)
        {
            UserId = userId;
        }
    }

    public class SendConfirmEmailCommandValidator : AbstractValidator<SendConfirmEmailCommand>
    {
        public SendConfirmEmailCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class SendConfirmEmailCommandHandler : IRequestHandler<SendConfirmEmailCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IEmailClient _emailClient;
        private readonly UserManager<User> _userManager;
        private readonly IEmailAssistant _emailAssistant;

        public SendConfirmEmailCommandHandler(PowerLiftingContext context, IEmailClient emailClient, UserManager<User> userManager, IEmailAssistant emailAssistant)
        {
            _context = context;
            _emailClient = emailClient;
            _userManager = userManager;
            _emailAssistant = emailAssistant;
        }

        public async Task<Unit> Handle(SendConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            //var emailTemplate = await _context.EmailTemplate
            //    .AsNoTracking()
            //    .Where(x => x.EmailTemplateId == 1) // replace with enum
            //    .FirstOrDefaultAsync();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmLink = $"{_emailAssistant.BaseUrl}/account/confirmemail?userId={user.Id}&token={token}";

            var emailMessage = new EmailMessage(new List<string>() { user.Email }, "PowerBuddy - Confirm Email", confirmLink);

            await _emailClient.SendEmailAsync(emailMessage);

            return Unit.Value;
        }
    }
}