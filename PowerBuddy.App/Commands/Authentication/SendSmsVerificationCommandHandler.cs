using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.SmsService;

namespace PowerBuddy.App.Commands.Authentication
{
    public class SendSmsVerificationCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public string PhoneNumber { get; }
        public string Code { get; }
        public string UserId { get; }

        public SendSmsVerificationCommand(string phoneNumber, string code, string userId)
        {
            PhoneNumber = phoneNumber;
            Code = code;
            UserId = userId;
        }
    }

    public class SendSmsVerificationCommandValidator : AbstractValidator<SendSmsVerificationCommand>
    {
        public SendSmsVerificationCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class SendSmsVerificationCommandHandler : IRequestHandler<SendSmsVerificationCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ISmsClient _smsClient;

        public SendSmsVerificationCommandHandler(PowerLiftingContext context, ISmsClient smsClient)
        {
            _context = context;
            _smsClient = smsClient;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(SendSmsVerificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                return new UserNotFound();
            }

            var numberIsVerified = await _smsClient.VerifyPhoneNumber(request.PhoneNumber, request.Code);

            if (numberIsVerified)
            {
                user.PhoneNumber = request.PhoneNumber;
                user.PhoneNumberConfirmed = true;
                await _context.SaveChangesAsync();
            }

            return numberIsVerified;
        }
    }
}