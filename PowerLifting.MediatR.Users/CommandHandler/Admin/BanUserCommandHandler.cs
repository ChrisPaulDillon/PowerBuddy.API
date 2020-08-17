using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Command.Admin;
using PowerLifting.MediatR.Users.Command.Public;

namespace PowerLifting.MediatR.Users.CommandHandler.Admin
{
    public class BanUserCommandHandler : IRequestHandler<BanUserCommand, bool>
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

            var adminUser = await _context.User.Where(x => x.Id == request.AdminUserId && x.Rights >= 1).Select(x => x.UserName).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (string.IsNullOrEmpty(adminUser)) throw new UserNotFoundException();

            userToBan.IsBanned = true;
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}