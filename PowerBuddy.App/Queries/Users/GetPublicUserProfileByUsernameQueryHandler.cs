using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Queries.Users
{
    public class GetPublicUserProfileByUsernameQuery : IRequest<OneOf<PublicUserDTO, UserNotFound>>
    {
        public string Username { get; }

        public GetPublicUserProfileByUsernameQuery(string username)
        {
            Username = username;
        }
    }

    public class GetPublicUserProfileByUsernameQueryValidator : AbstractValidator<GetPublicUserProfileByUsernameQuery>
    {
        public GetPublicUserProfileByUsernameQueryValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetPublicUserProfileByUsernameQueryHandler : IRequestHandler<GetPublicUserProfileByUsernameQuery, OneOf<PublicUserDTO, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetPublicUserProfileByUsernameQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<PublicUserDTO, UserNotFound>> Handle(GetPublicUserProfileByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.Where(x => x.NormalizedUserName == request.Username.ToUpper())
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null)
            {
                return new UserNotFound();
            }

            return user;
        }
    }
}
