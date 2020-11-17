using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogWeeks.Querys.Account
{
    public class GetProgramLogWeekByWeekNoQuery : IRequest<ProgramLogWeekDTO>
    {
        public int ProgramLogId { get; }
        public int WeekNo { get; }

        public GetProgramLogWeekByWeekNoQuery(int programLogId, int weekNo)
        {
            ProgramLogId = programLogId;
            WeekNo = weekNo;
            new GetProgramLogWeekByWeekNoQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogWeekByWeekNoQueryValidator : AbstractValidator<GetProgramLogWeekByWeekNoQuery>
    {
        public GetProgramLogWeekByWeekNoQueryValidator()
        {
            RuleFor(x => x.WeekNo).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.ProgramLogId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

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

