﻿using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.DTOs.Workouts;
using System.Threading;
using System.Threading.Tasks;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Workouts.Commands
{
    public class CreateWorkoutTemplateCommand : IRequest<Unit>
    {
        public WorkoutTemplateDTO WorkoutTemplateDTO { get; }
        public string UserId { get; }

        public CreateWorkoutTemplateCommand(WorkoutTemplateDTO workoutTemplateDTO, string userId)
        {
            WorkoutTemplateDTO = workoutTemplateDTO;
            UserId = userId;
            new CreateWorkoutTemplateCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class CreateWorkoutTemplateCommandValidator : AbstractValidator<CreateWorkoutTemplateCommand>
    {
        public CreateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
           // RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class CreateWorkoutTemplateCommandHandler : IRequestHandler<CreateWorkoutTemplateCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateWorkoutTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            var workoutTemplate = _mapper.Map<WorkoutTemplate>(request.WorkoutTemplateDTO);

            _context.WorkoutTemplate.Add(workoutTemplate);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}