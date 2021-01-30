using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Factories;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.Commands.Workouts
{
    public class CreateWorkoutLogFromScratchCommand : IRequest<WorkoutLog>
    {
        public WorkoutLogInputScratchDTO WorkoutLogDTO { get; }
        public string UserId { get; }

        public CreateWorkoutLogFromScratchCommand(WorkoutLogInputScratchDTO workoutLogDTO, string userId)
        {
            WorkoutLogDTO = workoutLogDTO;
            UserId = userId;
        }
    }

    public class CreateWorkoutLogFromScratchCommandValidator : AbstractValidator<CreateWorkoutLogFromScratchCommand>
    {
        public CreateWorkoutLogFromScratchCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDTO.NoOfWeeks).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
            RuleFor(x => x.WorkoutLogDTO.UserId).Matches(x => x.UserId).WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.WorkoutLogDTO.CustomName).MaximumLength(180).WithMessage("'{PropertyName}' should be no longer than {MaxLength} characters.");
        }
    }

    public class CreateWorkoutLogFromScratchCommandHandler : IRequestHandler<CreateWorkoutLogFromScratchCommand, WorkoutLog>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;

        public CreateWorkoutLogFromScratchCommandHandler(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task<WorkoutLog> Handle(CreateWorkoutLogFromScratchCommand request, CancellationToken cancellationToken)
        {
            if (request.WorkoutLogDTO.UserId != request.UserId)
            {
                throw new UserNotFoundException();
            }
          
            var listOfWorkoutDays = new List<WorkoutDayDTO>();

            var startDate = request.WorkoutLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);

            for (var i = 0; i < request.WorkoutLogDTO.NoOfWeeks; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    var workoutDay = _dtoFactory.CreateWorkoutDay(startDate, i, request.UserId);
                    listOfWorkoutDays.Add(workoutDay);
                    startDate = startDate.AddDays(1);
                }
            }

            request.WorkoutLogDTO.WorkoutDays = listOfWorkoutDays;

            var programLogEntity = _mapper.Map<WorkoutLog>(request.WorkoutLogDTO);

            _context.WorkoutLog.Add(programLogEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return programLogEntity;
        }
    }
}
