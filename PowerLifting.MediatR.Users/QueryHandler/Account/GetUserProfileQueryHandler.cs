using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Query.Account;

namespace PowerLifting.MediatR.Users.QueryHandler.Account
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId)) throw new UserValidationException("UserId cannot be empty");

            var user = await _context.User
                .Where(x => x.Id == request.UserId)
                .AsNoTracking()
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            user.UserSetting = await _context.UserSetting
                .AsNoTracking()
                .ProjectTo<UserSettingDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken: cancellationToken);

            return user;
        }
    }
}
