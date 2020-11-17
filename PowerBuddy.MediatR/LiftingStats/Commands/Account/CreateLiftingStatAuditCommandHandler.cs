using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Context;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.LiftingStats.Commands.Account
{
    public class CreateLiftingStatAuditCommand : IRequest<Unit>
    {
        public int LiftingStatId { get; }
        public int ExerciseId { get; }
        public int RepRange { get; }
        public decimal Weight { get; }
        public string UserId { get; }
        public DateTime Date { get; }

        public CreateLiftingStatAuditCommand(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId, DateTime date)
        {
            LiftingStatId = liftingStatId;
            ExerciseId = exerciseId;
            RepRange = repRange;
            Weight = weight;
            UserId = userId;
            Date = date;
            new CreateLiftingStatAuditCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateLiftingStatAuditCommandValidator : AbstractValidator<CreateLiftingStatAuditCommand>
    {
        public CreateLiftingStatAuditCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.RepRange).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
            RuleFor(x => x.Weight).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
        }
    }

    public class CreateLiftingStatAuditCommandHandler : IRequestHandler<CreateLiftingStatAuditCommand, Unit>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateLiftingStatAuditCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLiftingStatAuditCommand request, CancellationToken cancellationToken)
        {
            var liftingStatAudit = new LiftingStatAudit()
            {
                LiftingStatId = request.LiftingStatId,
                ExerciseId = request.ExerciseId,
                RepRange = request.RepRange,
                Weight = request.Weight,
                UserId = request.UserId,
                DateChanged = request.Date
            };

            _context.LiftingStatAudit.Add(liftingStatAudit);
            return Unit.Value;
        }
    }
}
