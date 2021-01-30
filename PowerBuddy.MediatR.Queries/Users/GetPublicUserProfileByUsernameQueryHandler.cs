using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Queries.Users
{
    public class GetPublicUserProfileByUsernameQuery : IRequest<PublicUserDTO>
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

    internal class GetPublicUserProfileByUsernameQueryHandler : IRequestHandler<GetPublicUserProfileByUsernameQuery, PublicUserDTO>
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
            var user = await _context.User.Where(x => x.NormalizedUserName == request.Username.ToUpper())
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            return user;
        }
    }
}
