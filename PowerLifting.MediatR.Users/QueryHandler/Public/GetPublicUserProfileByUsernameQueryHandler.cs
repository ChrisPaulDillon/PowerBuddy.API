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
using PowerLifting.MediatR.Users.Query.Public;

namespace PowerLifting.MediatR.Users.QueryHandler.Public
{
    public class GetPublicUserProfileByUsernameQueryHandler : IRequestHandler<GetPublicUserProfileByUsernameQuery, PublicUserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetPublicUserProfileByUsernameQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PublicUserDTO> Handle(GetPublicUserProfileByUsernameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Username)) throw new UserValidationException("UserId cannot be empty");

            var user = await _context.User.Where(x => x.NormalizedUserName == request.Username.ToUpper())
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            return user;
        }
    }
}
