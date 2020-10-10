using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Command.Account;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class DeleteProgramLogCommandHandler : IRequestHandler<DeleteProgramLogCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public DeleteProgramLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProgramLogCommand request, CancellationToken cancellationToken)
        {
            var doesLogExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (!doesLogExist) throw new ProgramLogNotFoundException();

            _context.ProgramLog.Remove(new ProgramLog() { ProgramLogId = request.ProgramLogId });

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
