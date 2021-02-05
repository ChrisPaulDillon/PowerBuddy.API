using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Exceptions.Workouts;

namespace PowerBuddy.App.Queries.WorkoutDays
{
    public class GetWorkoutDayByIdQuery : IRequest<WorkoutDayDTO>
    {
        public int WorkoutDayId { get; }
        public string UserId { get; }

        public GetWorkoutDayByIdQuery(int programLogDayId, string userId)
        {
            WorkoutDayId = programLogDayId;
            UserId = userId;
        }
    }

    public class GetWorkoutDayByIdQueryValidator : AbstractValidator<GetWorkoutDayByIdQuery>
    {
        public GetWorkoutDayByIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutDayId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
        }
    }

    internal class GetWorkoutDayByIdQueryHandler : IRequestHandler<GetWorkoutDayByIdQuery, WorkoutDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetWorkoutDayByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkoutDayDTO> Handle(GetWorkoutDayByIdQuery request, CancellationToken cancellationToken)
        {
            var workoutDay = await _context.WorkoutDay.Where(x => x.WorkoutDayId == request.WorkoutDayId && x.UserId == request.UserId)
                .ProjectTo<WorkoutDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (workoutDay == null)
            {
                throw new WorkoutDayNotFoundException();
            }

            return workoutDay;
        }
    }
}
