using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.Exceptions.Account;

namespace PowerLifting.MediatR.Exercises.Querys.Admin
{
    public class GetAllUnapprovedExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    {
        public string UserId { get; }
        public GetAllUnapprovedExercisesQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllUnapprovedExercisesQueryHandler : IRequestHandler<GetAllUnapprovedExercisesQuery, IEnumerable<ExerciseDTO>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllUnapprovedExercisesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> Handle(GetAllUnapprovedExercisesQuery request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2);

            if (!isUserAdmin) throw new UnauthorisedUserException();

            return await _context.Exercise.Where(x => x.IsApproved == false)
                .AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
