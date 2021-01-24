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
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Workouts.Util;

namespace PowerBuddy.MediatR.WorkoutDays.Querys
{
    public class GetWorkoutDayByIdQuery : IRequest<WorkoutDayDTO>
    {
        public int WorkoutDayId { get; }
        public string UserId { get; }

        public GetWorkoutDayByIdQuery(int programLogDayId, string userId)
        {
            WorkoutDayId = programLogDayId;
            UserId = userId;
            new GetWorkoutDayByIdQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class GetWorkoutDayByIdQueryValidator : AbstractValidator<GetWorkoutDayByIdQuery>
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
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public GetWorkoutDayByIdQueryHandler(PowerLiftingContext context, IAccountService accountService, IMapper mapper)
        {
            _context = context;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<WorkoutDayDTO> Handle(GetWorkoutDayByIdQuery request, CancellationToken cancellationToken)
        {
            var isMetric = await _accountService.IsUserUsingMetric(request.UserId);

            var workoutDay = await _context.WorkoutDay.Where(x => x.WorkoutDayId == request.WorkoutDayId && x.UserId == request.UserId)
                .ProjectTo<WorkoutDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (workoutDay == null)
            {
                throw new WorkoutDayNotFoundException();
            }

            foreach (var workoutExercise in workoutDay.WorkoutExercises)
            {
                WorkoutHelper.ConvertReturnedWorkoutSets(isMetric, workoutExercise.WorkoutSets);
            }

            return workoutDay;
        }
    }
}
