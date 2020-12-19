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
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogWeeks.Querys.Account
{
    public class GetProgramLogWeekByWeekNoQuery : IRequest<ProgramLogWeekExtendedDTO>
    {
        public int ProgramLogId { get; }
        public int WeekNo { get; }
        public string UserId { get; }

        public GetProgramLogWeekByWeekNoQuery(int programLogId, int weekNo, string userId)
        {
            ProgramLogId = programLogId;
            WeekNo = weekNo;
            UserId = userId;
            new GetProgramLogWeekByWeekNoQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogWeekByWeekNoQueryValidator : AbstractValidator<GetProgramLogWeekByWeekNoQuery>
    {
        public GetProgramLogWeekByWeekNoQueryValidator()
        {
            RuleFor(x => x.WeekNo).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.ProgramLogId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must be valid");
        }
    }

    public class GetProgramLogWeekByWeekNoQueryHandler : IRequestHandler<GetProgramLogWeekByWeekNoQuery, ProgramLogWeekExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekByWeekNoQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekExtendedDTO> Handle(GetProgramLogWeekByWeekNoQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.ProgramLogWeek
                .AsNoTracking()
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.WeekNo == request.WeekNo && x.UserId == request.UserId)
                .ProjectTo<ProgramLogWeekExtendedDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            if (programLogWeek.TemplateProgramId != 0)
            {
                var templateName = await _context.TemplateProgram
                    .AsNoTracking()
                    .Where(x => x.TemplateProgramId == programLogWeek.TemplateProgramId)
                    .Select(x => x.Name)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                programLogWeek.TemplateName = templateName;
            }


            return programLogWeek;
        }
    }
}

