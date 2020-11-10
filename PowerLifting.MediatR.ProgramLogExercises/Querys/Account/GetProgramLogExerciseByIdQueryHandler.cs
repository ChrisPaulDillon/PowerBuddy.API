using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;

namespace PowerLifting.MediatR.ProgramLogExercises.Querys.Account
{
    public class GetProgramLogExerciseByIdQuery : IRequest<ProgramLogExerciseDTO>
    {
        public int ProgramLogExerciseId { get; }

        public GetProgramLogExerciseByIdQuery(int programLogExerciseId)
        {
            ProgramLogExerciseId = programLogExerciseId;
            new GetProgramLogExerciseByIdQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogExerciseByIdQueryValidator : AbstractValidator<GetProgramLogExerciseByIdQuery>
    {
        public GetProgramLogExerciseByIdQueryValidator()
        {
            RuleFor(x => x.ProgramLogExerciseId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
        }
    }

    public class GetProgramLogExerciseByIdQueryHandler : IRequestHandler<GetProgramLogExerciseByIdQuery, ProgramLogExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogExerciseByIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogExerciseDTO> Handle(GetProgramLogExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var programLogExercise = await _context.Set<ProgramLogExercise>()
                .Where(x => x.ProgramLogExerciseId == request.ProgramLogExerciseId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if(programLogExercise == null) throw new ProgramLogExerciseNotFoundException();

            return programLogExercise;
        }
    }
}
