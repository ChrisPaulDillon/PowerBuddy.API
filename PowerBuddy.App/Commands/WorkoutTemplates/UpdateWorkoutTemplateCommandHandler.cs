using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using PowerBuddy.App.Extensions.Validators;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.App.Commands.WorkoutTemplates
{
    public class UpdateWorkoutTemplateCommand : IRequest<bool>
    {
        public WorkoutTemplateDTO WorkoutTemplateDTO { get; }
        public string UserId { get; }

        public UpdateWorkoutTemplateCommand(WorkoutTemplateDTO workoutTemplateDTO, string userId)
        {
            WorkoutTemplateDTO = workoutTemplateDTO;
            UserId = userId;
        }
    }

    public class UpdateWorkoutTemplateCommandValidator : AbstractValidator<UpdateWorkoutTemplateCommand>
    {
        public UpdateWorkoutTemplateCommandValidator()
        {
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutName).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutTemplateId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than {ComparisonValue}");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutExercises).NotNull().WithMessage("'{PropertyName}' cannot be null");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutExercises).Must(x => x == null || x.Any()).WithMessage("'{PropertyName}' must have at least one exercise");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.WorkoutTemplateDTO.WorkoutExercises).NotNull().ValidWorkoutExerciseCollection();
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
            //    .AnyAsync(x => x.UserId == request.UserId && x.WorkoutTemplateId == request.WorkoutTemplateDTO.WorkoutTemplateId);

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