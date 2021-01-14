using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.EmailService;
using PowerBuddy.EmailService.Models;

namespace PowerBuddy.MediatR.Emails.Commands
{
    public class ConfirmEmailCommand : IRequest<Unit>
    {
        public string UserId { get; }

        public ConfirmEmailCommand(string userId)
        {
            UserId = userId;
        }
    }
    internal class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailClient _emailClient;

        public ConfirmEmailCommandHandler(PowerLiftingContext context, IMapper mapper, IEmailClient emailClient)
        {
            _context = context;
            _mapper = mapper;
            _emailClient = emailClient;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            var emailTemplate = await _context.EmailTemplate
                .AsNoTracking()
                .Where(x => x.EmailTemplateId == 1) // replace with enum
                .FirstOrDefaultAsync();

            var emailMessage = new EmailMessage(new List<string>() { user.Email }, emailTemplate.Subject, emailTemplate.Message );

            await _emailClient.SendEmailAsync(emailMessage);

            return Unit.Value;
        }
    }
}