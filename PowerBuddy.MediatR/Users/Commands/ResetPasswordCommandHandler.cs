using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.MediatR.Users.Models;

namespace PowerBuddy.MediatR.Users.Commands
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

    internal class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
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