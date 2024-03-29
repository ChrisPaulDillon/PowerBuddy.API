﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Queries.Workouts.Models;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.Workouts
{
    public class GetAllWorkoutStatsQuery : IRequest<OneOf<WorkoutStatExtendedDto, WorkoutLogNotFound>>
    {
        public string UserId { get; }

        public GetAllWorkoutStatsQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetAllWorkoutStatsQueryValidator : AbstractValidator<GetAllWorkoutStatsQuery>
    {
        public GetAllWorkoutStatsQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    internal class GetAllWorkoutStatsQueryHandler : IRequestHandler<GetAllWorkoutStatsQuery, OneOf<WorkoutStatExtendedDto, WorkoutLogNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetAllWorkoutStatsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<WorkoutStatExtendedDto, WorkoutLogNotFound>> Handle(GetAllWorkoutStatsQuery request, CancellationToken cancellationToken)
        {
            var workoutLogStats = await _context.WorkoutLog
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .ProjectTo<WorkoutLogStatDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            if (!workoutLogStats.Any())
            {
                return new WorkoutLogNotFound();
            }

            var workoutLogStatsExtended = new WorkoutStatExtendedDto()
            {
                UserId = workoutLogStats[0].UserId,
                LifetimeLogCount = workoutLogStats.Count,
                LifetimeDayCount = workoutLogStats.Sum(j => j.DayCount),
                LifetimeExerciseCount = workoutLogStats.Sum(x => x.ExerciseCount),
                WorkoutLogStats = workoutLogStats
            };

            return workoutLogStatsExtended;
        }
    }
}
