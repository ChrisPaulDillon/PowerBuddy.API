﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Commands.Authentication.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.App.Commands.Authentication
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string UserId { get; }
        public ChangePasswordInputDTO ChangePasswordInputDTO { get; }

        public ResetPasswordCommand(string userId, ChangePasswordInputDTO changePasswordInputDTO)
        {
            UserId = userId;
            ChangePasswordInputDTO = changePasswordInputDTO;
        }
    }

    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(x => x.ChangePasswordInputDTO.Token).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.ChangePasswordInputDTO.Password).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public ResetPasswordCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException();

            var result = await _userManager.ResetPasswordAsync(user, request.ChangePasswordInputDTO.Token, request.ChangePasswordInputDTO.Password);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}