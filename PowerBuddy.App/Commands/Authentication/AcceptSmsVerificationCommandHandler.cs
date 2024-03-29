﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.SmsService;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Authentication
{
    public class AcceptSmsVerificationCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public string PhoneNumber { get; }
        public string Code { get; }
        public string UserId { get; }

        public AcceptSmsVerificationCommand(string phoneNumber, string code, string userId)
        {
            PhoneNumber = phoneNumber;
            Code = code;
            UserId = userId;
        }
    }

    public class AcceptSmsVerificationCommandValidator : AbstractValidator<AcceptSmsVerificationCommand>
    {
        public AcceptSmsVerificationCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.Code).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class AcceptSmsVerificationCommandHandler : IRequestHandler<AcceptSmsVerificationCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ISmsClient _smsClient;

        public AcceptSmsVerificationCommandHandler(PowerLiftingContext context, ISmsClient smsClient)
        {
            _context = context;
            _smsClient = smsClient;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(AcceptSmsVerificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            var numberIsVerified = await _smsClient.VerifyPhoneNumber(request.PhoneNumber, request.Code);

            if (numberIsVerified)
            {
                user.PhoneNumber = request.PhoneNumber;
                user.PhoneNumberConfirmed = true;
                await _context.SaveChangesAsync(cancellationToken);
            }

            return numberIsVerified;
        }
    }
}