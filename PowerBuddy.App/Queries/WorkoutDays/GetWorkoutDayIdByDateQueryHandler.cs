using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Queries.WorkoutDays.Models;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Queries.WorkoutDays
{
    public class GetWorkoutDayIdByDateQuery : IRequest<GetWorkoutIdResponse>
    {
        public DateTime WorkoutDate { get; }
        public string UserId { get; }

        public GetWorkoutDayIdByDateQuery(DateTime workoutDate, string userId)
        {
            WorkoutDate = workoutDate;
            UserId = userId;
        }
    }

    public class GetWorkoutDayIdByDateQueryValidator : AbstractValidator<GetWorkoutDayIdByDateQuery>
    {
        public GetWorkoutDayIdByDateQueryValidator()
        {
            RuleFor(x => x.WorkoutDate).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    internal class GetWorkoutDayIdByDateQueryHandler : IRequestHandler<GetWorkoutDayIdByDateQuery, GetWorkoutIdResponse>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;
        public GetWorkoutDayIdByDateQueryHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
        }

        public async Task<GetWorkoutIdResponse> Handle(GetWorkoutDayIdByDateQuery request, CancellationToken cancellationToken)
        {
            var workoutDayId =  await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.Date.Date == request.WorkoutDate.Date && x.UserId == request.UserId)
                .Select(x => x.WorkoutDayId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (workoutDayId == 0) //Workout doesn't exist, return options for creating a workout
            {
                var workoutDayDetails = await _workoutService.GetWorkoutLogDetailsForWeek(request.WorkoutDate, request.UserId);

                var getWorkoutResponse = new GetWorkoutIdResponse()
                {
                    WorkoutDayId = 0,
                    WorkoutLogId = workoutDayDetails?.WorkoutLogId,
                    TemplateName = workoutDayDetails?.TemplateName,
                    WeekNo = workoutDayDetails?.WeekNo ?? 0
                };
                return getWorkoutResponse;
            }

            return new GetWorkoutIdResponse() { WorkoutDayId = workoutDayId};
        }
    }
}

