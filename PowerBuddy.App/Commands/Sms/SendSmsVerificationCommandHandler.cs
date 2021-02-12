using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.SmsService;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Sms
{
    public class SendSmsVerificationCommand : IRequest<OneOf<string, UserNotFound>>
    {
	    public string PhoneNumber { get; }
        public string UserId { get; }


        public SendSmsVerificationCommand(string phoneNumber, string userId)
        {
	        PhoneNumber = phoneNumber;
            UserId = userId;
        }
    }

    public class SendSmsVerificationCommandValidator : AbstractValidator<SendSmsVerificationCommand>
    {
        public SendSmsVerificationCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class SendSmsVerificationCommandHandler : IRequestHandler<SendSmsVerificationCommand, OneOf<string, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ISmsClient _smsClient;

        public SendSmsVerificationCommandHandler(PowerLiftingContext context, ISmsClient smsClient)
        {
            _context = context;
            _smsClient = smsClient;
        }

        public async Task<OneOf<string, UserNotFound>> Handle(SendSmsVerificationCommand request, CancellationToken cancellationToken)
        {
            var doesUserExist = await _context.User
                .AsNoTracking()
                .AnyAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (!doesUserExist)
            {
                return new UserNotFound();
            }

            var result = await  _smsClient.SendPhoneNumberVerification(request.PhoneNumber);

            return result;
        }
    }
}