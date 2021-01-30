using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.SmsService;

namespace PowerBuddy.MediatR.Commands.Authentication
{
    public class SendSmsVerificationCommand : IRequest<bool>
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

    public class SendSmsVerificationCommandHandler : IRequestHandler<SendSmsVerificationCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ISmsClient _smsClient;

        public SendSmsVerificationCommandHandler(PowerLiftingContext context, UserManager<User> userManager, ISmsClient smsClient)
        {
            _context = context;
            _userManager = userManager;
            _smsClient = smsClient;
        }

        public async Task<bool> Handle(SendSmsVerificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var numberIsVerified = await _smsClient.VerifyPhoneNumber(request.PhoneNumber, request.Code);

            if (numberIsVerified)
            {
                user.PhoneNumber = request.PhoneNumber;
                user.PhoneNumberConfirmed = true;
                await _context.SaveChangesAsync();
            }

            //var result = await _userManager.SendSmsVerificationAsync(user, Send.ChangePasswordInputDTO.Token, Send.ChangePasswordInputDTO.Password);

            //if (result.Succeeded)
            //{
            //    return true;
            //}

            return numberIsVerified;
        }
    }
}