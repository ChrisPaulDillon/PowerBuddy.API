using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;
using PowerBuddy.MediatR.Emails.Models;

namespace PowerBuddy.MediatR.Emails.Commands
{
    public class SendPasswordResetCommand : IRequest<Unit>
    {
        public string EmailAddress { get; }

        public SendPasswordResetCommand(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
    internal class SendPasswordResetCommandHandler : IRequestHandler<SendPasswordResetCommand, Unit>
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

        public async Task<Unit> Handle(SendPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .Where(x => x.NormalizedEmail.Equals(request.EmailAddress.ToUpper()))
                .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            //var emailTemplate = await _context.EmailTemplate
            //    .AsNoTracking()
            //    .Where(x => x.EmailTemplateId == 1) // replace with enum
            //    .FirstOrDefaultAsync();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"{_emailHelper.BaseUrl}/account/changepassword?userId={user.Id}&token={token}";

            var emailMessage = new EmailMessage(new List<string>() { user.Email }, "PowerBuddy - Reset Password", resetLink);

            await _emailClient.SendEmailAsync(emailMessage);

            return Unit.Value;
        }
    }
}