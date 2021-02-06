using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Queries.Users
{
    public class GetAllUsersByAdminQuery : IRequest<IEnumerable<AdminUserDTO>>
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
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetAllUsersByAdminQueryHandler : IRequestHandler<GetAllUsersByAdminQuery, IEnumerable<AdminUserDTO>>
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
            var users = await _context.User.ProjectTo<AdminUserDTO>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            return users;
        }
    }
}
