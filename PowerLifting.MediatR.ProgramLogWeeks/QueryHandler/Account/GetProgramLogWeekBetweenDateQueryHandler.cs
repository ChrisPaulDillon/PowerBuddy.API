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
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogWeeks.Query.Account;
using PowerLifting.Persistence;

namespace PowerLifting.MediatR.ProgramLogWeeks.QueryHandler.Account
{
    public class GetProgramLogWeekBetweenDateQueryHandler : IRequestHandler<GetProgramLogWeekBetweenDateQuery, ProgramLogWeekDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekBetweenDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekDTO> Handle(GetProgramLogWeekBetweenDateQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.Set<ProgramLogWeek>()
                .Where(x => x.UserId == request.UserId && request.Date.Date >= x.StartDate.Date &&
                            request.Date.Date <= x.EndDate.Date)
                .ProjectTo<ProgramLogWeekDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}
