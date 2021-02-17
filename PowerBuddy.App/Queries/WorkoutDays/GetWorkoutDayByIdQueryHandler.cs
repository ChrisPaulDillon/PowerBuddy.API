﻿using System.Linq;
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
        public string UserId { get; }

        public GetWorkoutDayByIdQuery(int workoutDayId, string userId)
        {
            WorkoutDayId = workoutDayId;
            UserId = userId;
        }
    }

    public class GetWorkoutDayByIdQueryValidator : AbstractValidator<GetWorkoutDayByIdQuery>
    {
        public GetWorkoutDayByIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutDayId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    internal class GetWorkoutDayByIdQueryHandler : IRequestHandler<GetWorkoutDayByIdQuery, OneOf<WorkoutDayDto, WorkoutDayNotFound>>
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
            var workoutDay = await _context.WorkoutDay.Where(x => x.WorkoutDayId == request.WorkoutDayId && x.UserId == request.UserId)
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
