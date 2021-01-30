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
    public class GetPublicUserProfileByIdQuery : IRequest<PublicUserDTO>
    {
        public string UserId { get; }

        public GetPublicUserProfileByIdQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetPublicUserProfileByIdQueryValidator : AbstractValidator<GetPublicUserProfileByIdQuery>
    {
        public GetPublicUserProfileByIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetPublicUserProfileByIdQueryHandler : IRequestHandler<GetPublicUserProfileByIdQuery, PublicUserDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetPublicUserProfileByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PublicUserDTO> Handle(GetPublicUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.User.Where(x => x.Id == request.UserId)
                .AsNoTracking()
                .ProjectTo<PublicUserDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            return user;
        }
    }
}
