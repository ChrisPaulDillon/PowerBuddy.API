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
    public class VerifyEmailCommand : IRequest<bool>
    {
        public string UserId { get; }
        public string Token { get; }

        public VerifyEmailCommand(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }

    internal class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly UserManager<User> _userManager;

        public VerifyEmailCommandHandler(PowerLiftingContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User
                .AsNoTracking()
                .Where(x => x.Id == request.UserId)
                .FirstOrDefaultAsync();

            if (user == null) throw new UnauthorisedUserException();

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}