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
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Models.Workouts;

namespace PowerBuddy.App.Queries.Workouts
{
    public class GetWorkoutLogByIdQuery : IRequest<OneOf<WorkoutLogDto, WorkoutLogNotFound>>
    {
        public int WorkoutLogId { get; }
        public string UserId { get; }

        public GetWorkoutLogByIdQuery(int workoutLogId, string userId)
        {
            WorkoutLogId = workoutLogId;
            UserId = userId;
        }
    }

    public class GetWorkoutLogByIdQueryValidator : AbstractValidator<GetWorkoutLogByIdQuery>
    {
        public GetWorkoutLogByIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetWorkoutLogByIdQueryHandler : IRequestHandler<GetWorkoutLogByIdQuery, OneOf<WorkoutLogDto, WorkoutLogNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetWorkoutLogByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<WorkoutLogDto, WorkoutLogNotFound>> Handle(GetWorkoutLogByIdQuery request, CancellationToken cancellationToken)
        {
            var workoutLogDto = await _context.WorkoutLog
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId && x.WorkoutLogId == request.WorkoutLogId)
                .ProjectTo<WorkoutLogDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutLogDto == null)
            {
                return new WorkoutLogNotFound();
            }

            return workoutLogDto;
        }
    }
}
