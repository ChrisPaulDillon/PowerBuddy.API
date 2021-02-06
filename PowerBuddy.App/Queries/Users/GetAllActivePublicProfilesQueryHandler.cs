using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;

namespace PowerBuddy.App.Queries.Users
{
    public class GetAllActivePublicProfilesQuery : IRequest<IEnumerable<PublicUserDto>>
    {
        public string UserId { get; }
        public GetAllActivePublicProfilesQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class EditProfileCommandValidator : AbstractValidator<GetAllActivePublicProfilesQuery>
    {
        public EditProfileCommandValidator()
        {
   
        }
    }

    internal class GetAllActivePublicProfilesQueryHandler : IRequestHandler<GetAllActivePublicProfilesQuery, IEnumerable<PublicUserDto>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllActivePublicProfilesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublicUserDto>> Handle(GetAllActivePublicProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.Where(x => x.IsPublic && x.Id != request.UserId)
                .AsNoTracking()
                .ProjectTo<PublicUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
