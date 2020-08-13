using System;
using System.Collections.Generic;
using System.Data;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class UpdateProgramLogCommandHandler : IRequestHandler<UpdateProgramLogCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateProgramLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateProgramLogCommand request, CancellationToken cancellationToken)
        {
            var doesLogExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.ProgramLogId == request.ProgramLogDTO.ProgramLogId && x.UserId == request.UserId);

            if (!doesLogExist) throw new ProgramLogNotFoundException();

            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Update(programLog);

            var changedRows = await _context.SaveChangesAsync(cancellationToken);
            return changedRows > 0;
        }
    }
}
