using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Commands.Workouts
{
    public class CreateWorkoutLogFromScratchCommand : IRequest<OneOf<WorkoutLog, UserNotFound>>
    {
        public WorkoutLogInputScratchDto WorkoutLogDto { get; }
        public string UserId { get; }

        public CreateWorkoutLogFromScratchCommand(WorkoutLogInputScratchDto workoutLogDto, string userId)
        {
            WorkoutLogDto = workoutLogDto;
            UserId = userId;
        }
    }

    public class CreateWorkoutLogFromScratchCommandValidator : AbstractValidator<CreateWorkoutLogFromScratchCommand>
    {
        public CreateWorkoutLogFromScratchCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDto.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDto.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.WorkoutLogDto.CustomName).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDto.CustomName).MaximumLength(30).WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }

    public class CreateWorkoutLogFromScratchCommandHandler : IRequestHandler<CreateWorkoutLogFromScratchCommand, OneOf<WorkoutLog, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDtoFactory _dtoFactory;

        public CreateWorkoutLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper, IDtoFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task<OneOf<WorkoutLog, UserNotFound>> Handle(CreateWorkoutLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.WorkoutLogDto.UserId != request.UserId)
            {
                return new UserNotFound();
            }
          
            var listOfWorkoutDays = new List<WorkoutDayDto>();

            var startDate = request.WorkoutLogDto.StartDate.StartOfWeek(DayOfWeek.Monday);

            for (var i = 0; i < request.WorkoutLogDto.NoOfWeeks; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    var workoutDay = _dtoFactory.CreateWorkoutDay(startDate, i, request.UserId);
                    listOfWorkoutDays.Add(workoutDay);
                    startDate = startDate.AddDays(1);
                }
            }

            request.WorkoutLogDto.WorkoutDays = listOfWorkoutDays;

            var workoutLogEntity = _mapper.Map<WorkoutLog>(request.WorkoutLogDto);

            await _context.WorkoutLog.AddAsync(workoutLogEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return workoutLogEntity;
        }
    }
}
