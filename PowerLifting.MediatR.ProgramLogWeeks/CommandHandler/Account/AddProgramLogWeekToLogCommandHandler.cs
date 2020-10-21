using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogWeeks.Command.Account;

namespace PowerLifting.MediatR.ProgramLogWeeks.CommandHandler.Account
{
    public class AddProgramLogWeekToLogCommandHandler : IRequestHandler<AddProgramLogWeekToLogCommand, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public AddProgramLogWeekToLogCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> Handle(AddProgramLogWeekToLogCommand request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId)
                .Include(x => x.ProgramLogWeeks)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLog == null) throw new ProgramLogNotFoundException();

            var lastProgramWeek = programLog.ProgramLogWeeks.OrderByDescending(x => x.WeekNo).FirstOrDefault();

            var programLogWeek = new ProgramLogWeek()
            {
                StartDate = lastProgramWeek.EndDate,
                EndDate = lastProgramWeek.EndDate.AddDays(7),
                ProgramLogId = request.ProgramLogId,
                UserId = request.UserId,
                WeekNo = lastProgramWeek.WeekNo + 1
            };

            _context.ProgramLogWeek.Add(programLogWeek);
            programLog.NoOfWeeks++;
            programLog.EndDate = programLog.EndDate.AddDays(7);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProgramLogWeekDTO>(programLogWeek);

        }
    }
}
