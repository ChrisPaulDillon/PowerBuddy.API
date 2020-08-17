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
    public class GetAllProgramDayDatesQueryHandler : IRequestHandler<GetAllProgramDayDatesQuery, IEnumerable<DateTime>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllProgramDayDatesQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DateTime>> Handle(GetAllProgramDayDatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Set<ProgramLogDay>()
                .Where(x => x.UserId == request.UserId)
                .Select(x => x.Date.Date)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
