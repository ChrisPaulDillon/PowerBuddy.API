﻿using System.Linq;
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

namespace PowerLifting.MediatR.ProgramLogs.Querys.Account
{
    public class GetActiveProgramLogByUserIdQuery : IRequest<ProgramLogDTO>
    {
        public string UserId { get; }

        public GetActiveProgramLogByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }

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
            var programLogDTO = await _context.ProgramLog.Where(x => x.UserId == request.UserId && x.Active && x.IsDeleted == false)
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