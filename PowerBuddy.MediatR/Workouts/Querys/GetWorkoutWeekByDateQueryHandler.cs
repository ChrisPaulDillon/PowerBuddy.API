using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs.Workouts;
using PowerBuddy.MediatR.Workouts.Models;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.Workouts.Querys
{
    public class GetWorkoutWeekByDateQuery : IRequest<WorkoutWeekSummaryDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetWorkoutWeekByDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
            new GetWorkoutWeekByDateQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class GetWorkoutWeekByDateQueryValidator : AbstractValidator<GetWorkoutWeekByDateQuery>
    {
        public GetWorkoutWeekByDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }
    internal class GetWorkoutWeekByDateQueryHandler : IRequestHandler<GetWorkoutWeekByDateQuery, WorkoutWeekSummaryDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;

        public GetWorkoutWeekByDateQueryHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService WorkoutService)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = WorkoutService;
        }

        public async Task<WorkoutWeekSummaryDTO> Handle(GetWorkoutWeekByDateQuery request, CancellationToken cancellationToken)
        {
            var minDate = request.Date.StartOfWeek(DayOfWeek.Monday);
            var maxDate = request.Date.ClosestDateByDay(DayOfWeek.Sunday);

            var workouts = await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.Date >= minDate && x.Date <= maxDate && x.UserId == request.UserId)
                .ProjectTo<WorkoutDaySummaryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var weekDates = Enumerable
                .Range(0, int.MaxValue)
                .Select(index => minDate.AddDays(index))
                .TakeWhile(date => date <= maxDate)
                .ToList();

            foreach (var dayDate in weekDates) //Fill in remaining dates with empty workout days
            {
                var hasWorkoutOnDate = workouts.Any(x => x.Date.Date == dayDate.Date);
                if (hasWorkoutOnDate)
                {
                    continue;
                }
                workouts.Add(new WorkoutDaySummaryDTO() { Date = dayDate, HasWorkoutData = false});
            }

            var workoutWeekSummary = new WorkoutWeekSummaryDTO()
            {
                WeekNo = workouts.Count > 0 ? workouts[0].WeekNo : 0,
                WorkoutDays = workouts.OrderBy(x => x.Date)
            };

            return workoutWeekSummary;
        }
    }
}
