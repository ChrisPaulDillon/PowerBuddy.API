using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class UpdateWorkoutTemplateCommand : IRequest<bool>
    {
        public WorkoutTemplateDto WorkoutTemplateDto { get; }
        public string UserId { get; }

        public UpdateWorkoutTemplateCommand(WorkoutTemplateDto workoutTemplateDto, string userId)
        {
            WorkoutTemplateDto = workoutTemplateDto;
            UserId = userId;
        }
    }

    public class UpdateWorkoutTemplateCommandValidator : AbstractValidator<UpdateWorkoutTemplateCommand>
    {
        public UpdateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateDto.WorkoutName).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutTemplateId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).NotNull().WithMessage("'{PropertyName}' cannot be null");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDto.WorkoutExercises).NotNull().ValidWorkoutExerciseCollection();
        }
    }

    public class UpdateWorkoutTemplateCommandHandler : IRequestHandler<UpdateWorkoutTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;

        public UpdateWorkoutTemplateCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateWorkoutTemplateCommand request, CancellationToken cancellationToken)
        {
            //var workout = await _context.WorkoutTemplate
            //    .AsNoTracking()
            //    .AnyAsync(x => x.UserId == request.UserId && x.WorkoutTemplateId == request.WorkoutTemplateDto.WorkoutTemplateId);

            //if (!doesTemplateExist)
            //{
            //    return false;
            //}

            //_context.WorkoutTemplate.Remove(workoutTemplate);
            //var modifiedRows = await _context.SaveChangesAsync();

            return true;
        }
    }
}