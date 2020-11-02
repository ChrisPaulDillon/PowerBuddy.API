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
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogs.Query.Account;
using PowerLifting.Service.Account;
using PowerLifting.Service.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogs.QueryHandler.Account
{
    public class GetProgramLogByIdQueryHandler : IRequestHandler<GetProgramLogByIdQuery, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IProgramLogService _programLogService;

        public GetProgramLogByIdQueryHandler(PowerLiftingContext context, IMapper mapper, IAccountService accountService, IProgramLogService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
            _programLogService = programLogService;
        }

        public async Task<ProgramLogDTO> Handle(GetProgramLogByIdQuery request, CancellationToken cancellationToken)
        {
            var programLogDTO = await _context.ProgramLog.Where(x => x.ProgramLogId == request.ProgramLogId && x.IsDeleted == false)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDTO == null) throw new ProgramLogNotFoundException();

            var isUserProfilePublic = await _accountService.IsUserProfilePublic(request.UserId);

            if (programLogDTO.UserId != request.UserId && !isUserProfilePublic) //User is looking at another users diary, and it's not public
            {
                throw new UserProfileNotPublicException();
            }

            programLogDTO.LogDates = await _programLogService.GetAllProgramLogDatesForUser(request.UserId);

            return programLogDTO;
        }
    }
}
