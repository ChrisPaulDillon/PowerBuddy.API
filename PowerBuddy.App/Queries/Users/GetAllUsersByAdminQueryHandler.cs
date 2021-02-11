using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.Users
{
    public class GetAllUsersByAdminQuery : IRequest<IEnumerable<AdminUserDto>>
    {
        public string UserId { get; }

        public GetAllUsersByAdminQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllUsersByAdminQueryValidator : AbstractValidator<GetAllUsersByAdminQuery>
    {
        public GetAllUsersByAdminQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    internal class GetAllUsersByAdminQueryHandler : IRequestHandler<GetAllUsersByAdminQuery, IEnumerable<AdminUserDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersByAdminQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdminUserDto>> Handle(GetAllUsersByAdminQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.User.ProjectTo<AdminUserDto>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return users;
        }
    }
}
