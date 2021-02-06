using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class CreateWorkoutTemplateCommand : IRequest<WorkoutTemplate>
    {
        public WorkoutTemplateDto WorkoutTemplateDto { get; }
        public string UserId { get; }

        public CreateWorkoutTemplateCommand(WorkoutTemplateDto workoutTemplateDto, string userId)
        {
            WorkoutTemplateDto = workoutTemplateDto;
            UserId = userId;
        }
    }

    public class CreateWorkoutTemplateCommandValidator : AbstractValidator<CreateWorkoutTemplateCommand>
    {
        public CreateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateDto.WorkoutName).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDto.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).NotNull().WithMessage("'{PropertyName}' cannot be null");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).ValidWorkoutExerciseCollection();
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
            var workoutTemplate = _mapper.Map<WorkoutTemplate>(request.WorkoutTemplateDto);

            await _context.WorkoutTemplate.AddAsync(workoutTemplate, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return workoutTemplate;
        }
    }
}