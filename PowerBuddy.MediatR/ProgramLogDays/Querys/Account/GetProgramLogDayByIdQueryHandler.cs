using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogDays.Querys.Account
{
    public class GetProgramLogDayByIdQuery : IRequest<ProgramLogDayDTO>
    {
        public int ProgramLogDayId { get; }
        public string UserId { get; }

        public GetProgramLogDayByIdQuery(int programLogDayId, string userId)
        {
            ProgramLogDayId = programLogDayId;
            UserId = userId;
            new GetProgramLogDayByIdQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogDayByIdQueryValidator : AbstractValidator<GetProgramLogDayByIdQuery>
    {
        public GetProgramLogDayByIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogDayId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
        }
    }

    public class GetProgramLogDayByIdQueryHandler : IRequestHandler<GetProgramLogDayByIdQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramLogDayByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramLogDayByIdQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.ProgramLogDayId == request.ProgramLogDayId && x.UserId == request.UserId)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }
    }
}
