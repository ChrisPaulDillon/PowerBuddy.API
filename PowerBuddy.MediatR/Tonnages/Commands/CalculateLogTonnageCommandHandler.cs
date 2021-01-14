using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.Tonnages.Commands
{
    public class CalculateLogTonnageCommand : IRequest<bool>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public CalculateLogTonnageCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }

    internal class CalculateLogTonnageCommandHandler : IRequestHandler<CalculateLogTonnageCommand, bool>
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