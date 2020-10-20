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
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;

namespace PowerLifting.MediatR.ProgramLogWeeks.QueryHandler.Account
{
    public class GetProgramLogWeekByWeekNoQueryHandler : IRequestHandler<GetProgramLogWeekByWeekNoQuery, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekByWeekNoQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> Handle(GetProgramLogWeekByWeekNoQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.ProgramLogWeek
                .AsNoTracking()
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.WeekNo == request.WeekNo)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}

