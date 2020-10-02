using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.Tonnages.Command.Account;

namespace PowerLifting.MediatR.Tonnages.CommandHandler.Account
{
    public class CalculateLogTonnageCommandHandler : IRequestHandler<CalculateLogTonnageCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CalculateLogTonnageCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CalculateLogTonnageCommand request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId);

            if (programLog == null) throw new ProgramLogNotFoundException();
            return true;
        }
    }
}