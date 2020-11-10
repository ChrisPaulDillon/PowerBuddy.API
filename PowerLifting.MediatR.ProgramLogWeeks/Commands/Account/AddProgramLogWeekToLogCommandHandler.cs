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
using PowerLifting.Data.Factories;

namespace PowerLifting.MediatR.ProgramLogWeeks.Commands.Account
{
    public class AddProgramLogWeekToLogCommand : IRequest<ProgramLogWeekDTO>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public AddProgramLogWeekToLogCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }

    public class AddProgramLogWeekToLogCommandHandler : IRequestHandler<AddProgramLogWeekToLogCommand, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;

        public AddProgramLogWeekToLogCommandHandler(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task<ProgramLogWeekDTO> Handle(AddProgramLogWeekToLogCommand request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId)
                .Include(x => x.ProgramLogWeeks)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLog == null) throw new ProgramLogNotFoundException();

            var lastProgramWeek = programLog.ProgramLogWeeks.OrderByDescending(x => x.WeekNo).FirstOrDefault();

            var programLogWeek = _dtoFactory.CreateProgramLogWeekDTO(lastProgramWeek.EndDate,lastProgramWeek.WeekNo + 1, request.UserId);

            programLogWeek.ProgramLogId = lastProgramWeek.ProgramLogId;

            _context.ProgramLogWeek.Add(_mapper.Map<ProgramLogWeek>(programLogWeek));
            programLog.NoOfWeeks++;
            programLog.EndDate = programLog.EndDate.AddDays(7);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProgramLogWeekDTO>(programLogWeek);

        }
    }
}
