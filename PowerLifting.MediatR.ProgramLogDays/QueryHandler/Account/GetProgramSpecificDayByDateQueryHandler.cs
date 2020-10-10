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
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogDays.Query.Account;

namespace PowerLifting.MediatR.ProgramLogDays.QueryHandler.Account
{
    public class GetProgramSpecificDayByDateQueryHandler : IRequestHandler<GetProgramSpecificDayByDateQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramSpecificDayByDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramSpecificDayByDateQuery request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog.AsNoTracking().ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId);

            if (programLog == null) throw new ProgramLogNotFoundException();

            var programLogWeek = programLog.ProgramLogWeeks.FirstOrDefault(x => request.Date.Date >= x.StartDate.Date &&
                                                                                request.Date.Date <= x.EndDate.Date);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            var programLogDay = programLogWeek.ProgramLogDays.FirstOrDefault(x => x.UserId == request.UserId
                                                                                  && DateTime.Compare(request.Date.Date,
                                                                                      x.Date.Date) == 0);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();
            return programLogDay;
        }
    }
}
