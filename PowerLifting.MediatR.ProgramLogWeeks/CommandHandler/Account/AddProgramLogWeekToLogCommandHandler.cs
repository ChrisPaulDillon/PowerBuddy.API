using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogWeeks.Command.Account;
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;

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
                WeekNo = lastProgramWeek.WeekNo++
            };

            _context.ProgramLogWeek.Add(programLogWeek);
            programLog.NoOfWeeks++;

            await _context.SaveChangesAsync();

            return _mapper.Map<ProgramLogWeekDTO>(programLogWeek);

        }
    }
}
