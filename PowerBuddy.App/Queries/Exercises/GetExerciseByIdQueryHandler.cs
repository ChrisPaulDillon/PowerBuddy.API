using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Repositories.Exercises;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Exercises;
using PowerBuddy.Data.Models.Exercises;

namespace PowerBuddy.App.Queries.Exercises
{
    public class GetExerciseByIdQuery : IRequest<OneOf<ExerciseDto, ExerciseNotFound>>
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

    internal class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, OneOf<ExerciseDto, ExerciseNotFound>>
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

        public async Task<OneOf<ExerciseDto, ExerciseNotFound>> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise =  await _context.Exercise
                .AsNoTracking()
                .ProjectTo<ExerciseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.ExerciseId == request.ExerciseId);

            if (exercise == null)
            {
                return new ExerciseNotFound();
            }

            return exercise;
        }
    }
}
