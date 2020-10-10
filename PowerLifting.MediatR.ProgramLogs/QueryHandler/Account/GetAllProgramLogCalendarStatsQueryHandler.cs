﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.MediatR.ProgramLogs.Query.Account;

namespace PowerLifting.MediatR.ProgramLogs.QueryHandler.Account
{
    public class GetAllProgramLogCalendarStatsQueryHandler : IRequestHandler<GetAllProgramLogCalendarStatsQuery, ProgramLogCalendarDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetAllProgramLogCalendarStatsQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogCalendarDTO> Handle(GetAllProgramLogCalendarStatsQuery request, CancellationToken cancellationToken)
        {
            var workoutDates = await _context.Set<ProgramLogDay>()
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .Select(x => x.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            var personalBests = await _context.ProgramLogDay
                .AsNoTracking()
                .Where(x => x.PersonalBest == true && x.UserId == request.UserId)
                .Select(x => x.Date)
                .ToListAsync(cancellationToken: cancellationToken);

            var programLogCalendarDTO = new ProgramLogCalendarDTO()
            {
                WorkoutDates = workoutDates,
                PersonalBestDates = personalBests
            };

            return programLogCalendarDTO;
        }
    }
}
