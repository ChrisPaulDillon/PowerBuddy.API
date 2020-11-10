using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediatR.Users.Querys.Admin
{
    public class GetAllUsersByAdminQuery : IRequest<IEnumerable<AdminUserDTO>>
    {
        public string UserId { get; }

        public GetAllUsersByAdminQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllUsersByAdminQueryHandler : IRequestHandler<GetAllUsersByAdminQuery, IEnumerable<AdminUserDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllUsersByAdminQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminUserDTO>> Handle(GetAllUsersByAdminQuery request, CancellationToken cancellationToken)
        {
            var isUserAuthorized = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var users = await _context.User.ProjectTo<AdminUserDTO>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return users;
        }
    }
}
