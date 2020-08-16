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
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.MediatR.Users.Query.Account;
using PowerLifting.Persistence;

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
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            return user;
        }
    }
}
