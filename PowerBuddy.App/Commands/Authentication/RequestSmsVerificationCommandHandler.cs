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
using PowerBuddy.SmsService;

namespace PowerBuddy.App.Commands.Authentication
{
    public class RequestSmsVerificationCommand : IRequest<OneOf<string, UserNotFound>>
    {
        public string UserId { get; }
        public string PhoneNumber { get; }

        public RequestSmsVerificationCommand(string phoneNumber, string userId)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
        }
    }

    public class RequestSmsVerificationCommandValidator : AbstractValidator<RequestSmsVerificationCommand>
    {
        public RequestSmsVerificationCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class RequestSmsVerificationCommandHandler : IRequestHandler<RequestSmsVerificationCommand, OneOf<string, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ISmsClient _smsClient;

        public RequestSmsVerificationCommandHandler(PowerLiftingContext context, ISmsClient smsClient)
        {
            _context = context;
            _smsClient = smsClient;
        }

        public async Task<OneOf<string, UserNotFound>> Handle(RequestSmsVerificationCommand request, CancellationToken cancellationToken)
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