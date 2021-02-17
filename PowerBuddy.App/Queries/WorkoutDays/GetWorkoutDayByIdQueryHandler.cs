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
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.WorkoutDays
{
    public class GetWorkoutDayByIdQuery : IRequest<OneOf<WorkoutDayDto, WorkoutDayNotFound>>
    {
        public int WorkoutDayId { get; }

        public GetWorkoutDayByIdQuery(int workoutDayId)
        {
            WorkoutDayId = workoutDayId;
        }
    }

    public class GetWorkoutDayByIdQueryValidator : AbstractValidator<GetWorkoutDayByIdQuery>
    {
        public GetWorkoutDayByIdQueryValidator()
        {
	        RuleFor(x => x.WorkoutDayId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class GetWorkoutDayByIdQueryHandler : IRequestHandler<GetWorkoutDayByIdQuery, OneOf<WorkoutDayDto, WorkoutDayNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetWorkoutDayByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<WorkoutDayDto, WorkoutDayNotFound>> Handle(GetWorkoutDayByIdQuery request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context.WorkoutDay.Where(x => x.WorkoutDayId == request.WorkoutDayId)
	            .AsNoTracking()
                .ProjectTo<WorkoutDayDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutDay == null)
            {
                return new WorkoutDayNotFound();
            }

            return workoutDay;
        }
    }
}
