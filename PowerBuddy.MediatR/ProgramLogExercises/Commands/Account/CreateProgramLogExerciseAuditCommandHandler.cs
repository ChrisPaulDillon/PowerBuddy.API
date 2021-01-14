using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.ProgramLogExercises.Commands.Account
{
    public class CreateProgramLogExerciseAuditCommand : IRequest<Unit>
    {
        public int ExerciseId { get; }
        public string UserId { get; }

        public CreateProgramLogExerciseAuditCommand(int exerciseId, string userId)
        {
            ExerciseId = exerciseId;
            UserId = userId;
            new CreateProgramLogExerciseAuditCommandValidator().ValidateAndThrow(this);
        }
    }

    internal class CreateProgramLogExerciseAuditCommandValidator : AbstractValidator<CreateProgramLogExerciseAuditCommand>
    {
        public CreateProgramLogExerciseAuditCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    internal class CreateProgramLogExerciseAuditCommandHandler : IRequestHandler<CreateProgramLogExerciseAuditCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogExerciseAuditCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProgramLogExerciseAuditCommand request, CancellationToken cancellationToken)
        {
            var exerciseAudit = await _context.ProgramLogExerciseAudit
                .Where(x => x.UserId == request.UserId && x.ExerciseId == request.ExerciseId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (exerciseAudit == null)
            {
                exerciseAudit = new ProgramLogExerciseAudit()
                {
                    ExerciseId = request.ExerciseId,
                    UserId = request.UserId,
                    SelectedCount = 1
                };
                _context.ProgramLogExerciseAudit.Add(exerciseAudit);
            }
            else
            {
                exerciseAudit.SelectedCount++;
            }
            return Unit.Value;
        }
    }
}