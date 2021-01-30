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
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Queries.Exercises.Querys
{
    public class GetAllUnapprovedExercisesQuery : IRequest<IEnumerable<ExerciseDTO>>
    {
        public string UserId { get; }
        public GetAllUnapprovedExercisesQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllUnapprovedExercisesQueryValidator : AbstractValidator<GetAllUnapprovedExercisesQuery>
    {
        public GetAllUnapprovedExercisesQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    internal class GetAllUnapprovedExercisesQueryHandler : IRequestHandler<GetAllUnapprovedExercisesQuery, IEnumerable<ExerciseDTO>>
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

            if (!isUserAdmin) throw new UserNotFoundException();

            return await _context.Exercise.Where(x => x.IsApproved == false)
                .AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
