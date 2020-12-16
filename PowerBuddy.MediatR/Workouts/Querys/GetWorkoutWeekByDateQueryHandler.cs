using System;
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
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.Workouts;

namespace PowerBuddy.MediatR.Workouts.Querys
{
    public class GetWorkoutWeekByDateQuery : IRequest<IEnumerable<WorkoutDayDTO>>
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

    public class GetWorkoutWeekByDateQueryValidator : AbstractValidator<GetWorkoutWeekByDateQuery>
    {
        public GetWorkoutWeekByDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }
    public class GetWorkoutWeekByDateQueryHandler : IRequestHandler<GetWorkoutWeekByDateQuery, IEnumerable<WorkoutDayDTO>>
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

        public async Task<IEnumerable<WorkoutDayDTO>> Handle(GetWorkoutWeekByDateQuery request, CancellationToken cancellationToken)
        {
            var minDate = request.Date.AddDays(-3);
            var maxDate = request.Date.AddDays(3);

            var workouts = await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.Date >= minDate && x.Date <= maxDate)
                //.ProjectTo<WorkoutDayDTO>(_mapper.ConfigurationProvider)
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
                workouts.Add(new WorkoutDay() { Date = dayDate});
            }

            return new List<WorkoutDayDTO>();
        }
    }
}
