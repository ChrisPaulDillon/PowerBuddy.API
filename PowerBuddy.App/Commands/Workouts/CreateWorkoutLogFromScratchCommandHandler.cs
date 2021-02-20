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
using PowerBuddy.Data.Models.Account;
using PowerBuddy.Util;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Commands.Workouts
{
    public class CreateWorkoutLogFromScratchCommand : IRequest<OneOf<bool, UserNotFound>>
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
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutLogDto.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutLogDto.NoOfWeeks).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.WorkoutLogDto.CustomName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutLogDto.CustomName).MaximumLength(30).WithMessage(ValidationConstants.MAX_LENGTH);
        }
    }

    public class CreateWorkoutLogFromScratchCommandHandler : IRequestHandler<CreateWorkoutLogFromScratchCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateWorkoutLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(CreateWorkoutLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.WorkoutLogDto.UserId != request.UserId)
            {
                return new UserNotFound();
            }
          
            var listOfWorkoutDays = new List<WorkoutDayDto>();

            var startDate = request.WorkoutLogDto.StartDate.StartOfWeek(DayOfWeek.Monday);

            for (var i = 1; i < request.WorkoutLogDto.NoOfWeeks + 1; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    var workoutDay =  new WorkoutDayDto()
                    {
                        Date = startDate,
                        WeekNo = i,
                        UserId = request.UserId,
                        WorkoutExercises = new List<WorkoutExerciseDto>(),
                    };
                    listOfWorkoutDays.Add(workoutDay);
                    startDate = startDate.AddDays(1);
                }
            }

            request.WorkoutLogDto.WorkoutDays = listOfWorkoutDays;

            var workoutLogEntity = _mapper.Map<WorkoutLog>(request.WorkoutLogDto);

            await _context.WorkoutLog.AddAsync(workoutLogEntity, cancellationToken);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}
