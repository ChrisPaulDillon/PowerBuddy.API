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
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Query.Account;

namespace PowerLifting.MediatR.ProgramLogExercises.QueryHandler.Account
{ 
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
