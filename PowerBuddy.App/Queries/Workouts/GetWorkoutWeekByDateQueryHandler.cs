﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Queries.Workouts.Models;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Queries.Workouts
{
    public class GetWorkoutWeekByDateQuery : IRequest<WorkoutWeekSummaryDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetWorkoutWeekByDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
        }
    }

    public class GetWorkoutWeekByDateQueryValidator : AbstractValidator<GetWorkoutWeekByDateQuery>
    {
        public GetWorkoutWeekByDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    internal class GetWorkoutWeekByDateQueryHandler : IRequestHandler<GetWorkoutWeekByDateQuery, WorkoutWeekSummaryDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetWorkoutWeekByDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            if (workouts.Count() < 7) //Full workout week, don't bother attempting to add empty days
            {
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
                    workouts.Add(new WorkoutDaySummaryDTO() { Date = dayDate, HasWorkoutData = false });
                }
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
