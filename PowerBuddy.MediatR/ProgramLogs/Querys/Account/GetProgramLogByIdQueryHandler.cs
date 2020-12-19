using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.Account;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogs.Querys.Account
{
    public class GetProgramLogByIdQuery : IRequest<ProgramLogDTO>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public GetProgramLogByIdQuery(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
        }
    }

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
            var programLogDTO = await _context.ProgramLog.Where(x => x.ProgramLogId == request.ProgramLogId)
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
