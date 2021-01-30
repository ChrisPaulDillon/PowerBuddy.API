using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Commands.Workouts
{
    public class CreateWorkoutTemplateCommand : IRequest<Unit>
    {
        public WorkoutTemplateDTO WorkoutTemplateDTO { get; }
        public string UserId { get; }

        public CreateWorkoutTemplateCommand(WorkoutTemplateDTO workoutTemplateDTO, string userId)
        {
            WorkoutTemplateDTO = workoutTemplateDTO;
            UserId = userId;
        }
    }

    public class CreateWorkoutTemplateCommandValidator : AbstractValidator<CreateWorkoutTemplateCommand>
    {
        public CreateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
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