using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class CreateWorkoutTemplateCommand : IRequest<WorkoutTemplate>
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
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutName).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDTO.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutExercises).NotNull().WithMessage("'{PropertyName}' cannot be null");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class CreateWorkoutTemplateCommandHandler : IRequestHandler<CreateWorkoutTemplateCommand, WorkoutTemplate>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateWorkoutTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkoutTemplate> Handle(CreateWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            var workoutTemplate = _mapper.Map<WorkoutTemplate>(request.WorkoutTemplateDTO);

            _context.WorkoutTemplate.Add(workoutTemplate);
            await _context.SaveChangesAsync();

            return workoutTemplate;
        }
    }
}