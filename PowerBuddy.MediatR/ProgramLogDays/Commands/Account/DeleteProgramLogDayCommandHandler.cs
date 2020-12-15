using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogDays.Commands.Account
{
    public class DeleteProgramLogDayCommand : IRequest<bool>
    {
        public int ProgramLogDayId { get; }
        public string UserId { get; }

        public DeleteProgramLogDayCommand(int programLogDayId, string userId)
        {
            ProgramLogDayId = programLogDayId;
            UserId = userId;
            new DeleteProgramLogDayCommandValidator().ValidateAndThrow(this);
        }
    }

    public class DeleteProgramLogDayCommandValidator : AbstractValidator<DeleteProgramLogDayCommand>
    {
        public DeleteProgramLogDayCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class DeleteProgramLogDayCommandHandler : IRequestHandler<DeleteProgramLogDayCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public DeleteProgramLogDayCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProgramLogDayCommand request, CancellationToken cancellationToken)
        {
            var doesProgramLogDayExist = await _context.ProgramLogDay
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogDayId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!doesProgramLogDayExist) throw new ProgramLogDayNotFoundException();

            _context.ProgramLogDay.Remove(new ProgramLogDay() { ProgramLogDayId = request.ProgramLogDayId });

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}