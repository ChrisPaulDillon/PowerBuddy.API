using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Command.Account;

namespace PowerLifting.MediatR.ProgramLogDays.CommandHandler.Account
{
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