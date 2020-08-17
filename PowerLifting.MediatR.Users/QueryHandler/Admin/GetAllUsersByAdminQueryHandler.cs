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
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.Users.Query.Admin;

namespace PowerLifting.MediatR.Users.QueryHandler.Admin
{
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
            var isUserAuthorized = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.Rights > 1);

            if (!isUserAuthorized) throw new UnauthorisedUserException();

            var users = await _context.User.ProjectTo<AdminUserDTO>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return users;
        }
    }
}
