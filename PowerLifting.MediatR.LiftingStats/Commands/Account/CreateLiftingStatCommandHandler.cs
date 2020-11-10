using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.LiftingStats;

namespace PowerLifting.MediatR.LiftingStats.Commands.Account
{
    public class CreateLiftingStatCommand : IRequest<LiftingStatDTO>
    {
        public LiftingStatDTO LiftingStat { get; }
        public string UserId { get; }

        public CreateLiftingStatCommand(LiftingStatDTO liftingStat, string userId)
        {
            LiftingStat = liftingStat;
            UserId = userId;
            new CreateLiftingStatCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateLiftingStatCommandValidator : AbstractValidator<CreateLiftingStatCommand>
    {
        public CreateLiftingStatCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.LiftingStat.ExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
            RuleFor(x => x.LiftingStat.RepRange).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
            RuleFor(x => x.LiftingStat.Weight).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
        }
    }

    public class CreateLiftingStatCommandHandler : IRequestHandler<CreateLiftingStatCommand, LiftingStatDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateLiftingStatCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<LiftingStatDTO> Handle(CreateLiftingStatCommand request, CancellationToken cancellationToken)
        {
            var userId = request.LiftingStat.UserId;
            var repRange = request.LiftingStat.RepRange;

            if (userId != request.UserId) throw new UnauthorisedUserException();

            var doesLiftingStatExist = await _context.LiftingStat.Where(x => x.UserId == userId && x.ExerciseId == request.LiftingStat.ExerciseId && x.RepRange == repRange)
                .AsNoTracking()
                .AnyAsync(cancellationToken: cancellationToken);

            if (doesLiftingStatExist) throw new LiftingStatAlreadyExistsException();

            var createdLiftingStat = new LiftingStat()
            {
                UserId = request.LiftingStat.UserId,
                ExerciseId = request.LiftingStat.ExerciseId,
                RepRange = request.LiftingStat.RepRange,
                Weight = request.LiftingStat.Weight,
                GoalWeight = request.LiftingStat.GoalWeight,
                PercentageToGoal = request.LiftingStat.GoalWeight != null ? (request.LiftingStat.Weight / request.LiftingStat.GoalWeight) * 100 : null,
                LastUpdated = request.LiftingStat.LastUpdated,
            };

            _context.Add(createdLiftingStat);

            await _mediator.Send(new CreateLiftingStatAuditCommand(createdLiftingStat.LiftingStatId, createdLiftingStat.ExerciseId, createdLiftingStat.RepRange, (decimal)createdLiftingStat.Weight, createdLiftingStat.UserId, DateTime.UtcNow), cancellationToken);
            //var createdAudit = await _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);

            return request.LiftingStat;
        }
    }
}
