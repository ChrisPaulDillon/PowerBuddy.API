using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Exercises;
using PowerBuddy.Repositories.Exercises;

namespace PowerBuddy.MediatR.Queries.Exercises
{
    public class GetExerciseByIdQuery : IRequest<ExerciseDTO>
    {
        public int ExerciseId { get; }

        public GetExerciseByIdQuery(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }

    public class GetExerciseByIdQueryValidator : AbstractValidator<GetExerciseByIdQuery>
    {
        public GetExerciseByIdQueryValidator()
        {
            RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }

    internal class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDTO>
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetExerciseByIdQueryHandler(IExerciseRepository exerciseRepo, PowerLiftingContext context, IMapper mapper)
        {
            _exerciseRepo = exerciseRepo;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseDTO> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Exercise
                .AsNoTracking()
                .ProjectTo<ExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId);
        }
    }
}
