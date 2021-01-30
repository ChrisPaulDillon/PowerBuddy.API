using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Users.Commands
{
    public class BanUserCommand : IRequest<bool>
    {
        public string UserId { get; }
        public string AdminUserId { get; }

        public BanUserCommand(string userId, string adminUserId)
        {
            UserId = userId;
            AdminUserId = adminUserId;
        }
    }

    public class BanUserCommandValidator : AbstractValidator<BanUserCommand>
    {
        public BanUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.AdminUserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class BanUserCommandHandler : IRequestHandler<BanUserCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public BanUserCommandHandler(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Handle(BanUserCommand request, CancellationToken cancellationToken)
        {
            var userToBan = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

            if (userToBan == null) throw new UserNotFoundException();

            var adminUser = await _context.User.Where(x => x.Id == request.AdminUserId && x.MemberStatusId >= 2).Select(x => x.UserName).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (string.IsNullOrEmpty(adminUser)) throw new UserNotFoundException();

            userToBan.IsBanned = true;
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}