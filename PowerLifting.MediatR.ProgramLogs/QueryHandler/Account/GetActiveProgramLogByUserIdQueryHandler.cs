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
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Query.Account;

namespace PowerLifting.MediatR.ProgramLogs.QueryHandler.Account
{
    public class GetActiveProgramLogByUserIdQueryHandler : IRequestHandler<GetActiveProgramLogByUserIdQuery, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetActiveProgramLogByUserIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDTO> Handle(GetActiveProgramLogByUserIdQuery request, CancellationToken cancellationToken)
        {
            var programLogDTO = await _context.ProgramLog.Where(x => x.UserId == request.UserId && x.Active)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDTO == null) throw new ProgramLogNotFoundException();

            programLogDTO.LogDates = await _context.Set<ProgramLogDay>()
                .Where(x => x.UserId == request.UserId)
                .Select(x => x.Date.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            return programLogDTO;
        }
    }
}
