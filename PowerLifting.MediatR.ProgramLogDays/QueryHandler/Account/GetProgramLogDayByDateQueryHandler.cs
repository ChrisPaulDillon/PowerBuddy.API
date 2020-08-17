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
using PowerLifting.MediatR.ProgramLogDays.Query.Account;

namespace PowerLifting.MediatR.ProgramLogDays.QueryHandler.Account
{ 
    public class GetProgramLogDayByDateQueryHandler : IRequestHandler<GetProgramLogDayByDateQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramLogDayByDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramLogDayByDateQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.UserId == request.UserId && DateTime.Compare(request.Date.Date, x.Date.Date) == 0)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }
    }
}
