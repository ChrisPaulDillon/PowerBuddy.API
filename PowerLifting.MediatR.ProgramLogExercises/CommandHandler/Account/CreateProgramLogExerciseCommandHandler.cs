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
using PowerLifting.Data.Exceptions.Exercises;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.MediatR.ProgramLogExercises.Command.Account;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account
{
    public class CreateProgramLogExerciseCommandHandler : IRequestHandler<CreateProgramLogExerciseCommand, ProgramLogExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogExerciseCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogExerciseDTO> Handle(CreateProgramLogExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(
                x => x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);

            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var doesProgramExerciseExist = await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .AnyAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId
                               && x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId,
                    cancellationToken: cancellationToken);

            if (!doesProgramExerciseExist)
            {
                var noOfSets = request.ProgramLogExerciseDTO.NoOfSets;
                    var repSchemeCollection = new List<CProgramLogRepSchemeDTO>();

                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        if (request.ProgramLogExerciseDTO.Reps != null && request.ProgramLogExerciseDTO.Weight != null)
                        {
                            var repScheme = new CProgramLogRepSchemeDTO()
                            {
                                SetNo = i,
                                NoOfReps = (int) request.ProgramLogExerciseDTO.Reps,
                                WeightLifted = (decimal) request.ProgramLogExerciseDTO.Weight,
                            };
                            repSchemeCollection.Add(repScheme);
                        }
                    }

                    request.ProgramLogExerciseDTO.ProgramLogRepSchemes = repSchemeCollection;
                
                var programLogExerciseEntity = _mapper.Map<ProgramLogExercise>(request.ProgramLogExerciseDTO);
                _context.ProgramLogExercise.Add(programLogExerciseEntity);
                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
                //await CreateProgramLogExerciseAudit(userId, programLogExercise.ExerciseId);
            }
            else //exercise already exists for the given day, add to it
            {
                var programLogExerciseEntity = await _context.Set<ProgramLogExercise>()
                    .AsNoTracking()
                    .Include(x => x.ProgramLogRepSchemes)
                    .FirstOrDefaultAsync(x =>
                        x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId &&
                        x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);

                    var noOfSets = request.ProgramLogExerciseDTO.NoOfSets;
                    for (var i = 1; i < noOfSets + 1; i++)
                    {
                        if (request.ProgramLogExerciseDTO.Reps != null && request.ProgramLogExerciseDTO.Weight != null)
                        {
                            var repScheme = new ProgramLogRepScheme()
                            {
                                SetNo = i,
                                NoOfReps = (int) request.ProgramLogExerciseDTO.Reps,
                                WeightLifted = (decimal) request.ProgramLogExerciseDTO.Weight,
                            };
                            programLogExerciseEntity.ProgramLogRepSchemes.Add(repScheme);
                        }
                    }
                    
                programLogExerciseEntity.NoOfSets += request.ProgramLogExerciseDTO.NoOfSets;
                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
            }
        }
    }
}
