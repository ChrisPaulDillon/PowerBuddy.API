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
using PowerLifting.MediatR.ProgramLogExercises.Util;

namespace PowerLifting.MediatR.ProgramLogExercises.CommandHandler.Account
{
    public class CreateProgramLogExerciseCommandHandler : IRequestHandler<CreateProgramLogExerciseCommand, ProgramLogExerciseDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProgramLogExerciseCommandHandler(PowerLiftingContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ProgramLogExerciseDTO> Handle(CreateProgramLogExerciseCommand request, CancellationToken cancellationToken)
        {
            var doesExerciseExist = await _context.Exercise.AsNoTracking().AnyAsync(
                x => x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);

            if (!doesExerciseExist) throw new ExerciseNotFoundException();

            var programLogExerciseEntity = await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Include(x => x.ProgramLogRepSchemes)
                .FirstOrDefaultAsync(x => x.ProgramLogDayId == request.ProgramLogExerciseDTO.ProgramLogDayId && x.ExerciseId == request.ProgramLogExerciseDTO.ExerciseId, cancellationToken: cancellationToken);

            var noOfSetsToAdd = request.ProgramLogExerciseDTO.NoOfSets;

            if (programLogExerciseEntity == null) //no exercise found for this day
            { 
                var repSchemeCollection = new List<CProgramLogRepSchemeDTO>();

                    for (var i = 1; i < noOfSetsToAdd + 1; i++)
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
                
                var programLogExercise = _mapper.Map<ProgramLogExercise>(request.ProgramLogExerciseDTO);
                _context.ProgramLogExercise.Add(programLogExercise);

                await _mediator.Send(new CreateProgramLogExerciseAuditCommand(request.ProgramLogExerciseDTO.ExerciseId, request.UserId), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var mappedProgramLogExercise = _mapper.Map<ProgramLogExerciseDTO>(programLogExerciseEntity);
                return mappedProgramLogExercise;
            }
            else //exercise already exists for the given day, add to it
            {
                var totalNoOfSets = programLogExerciseEntity.NoOfSets + noOfSetsToAdd;
                if (totalNoOfSets >= ProgramLogExerciseConstants.MAX_NO_OF_SETS)
                {
                    throw new ReachedMaxSetsOnExerciseException();
                }

                for (var i = 1; i < noOfSetsToAdd + 1; i++)
                {
                    if (request.ProgramLogExerciseDTO.Reps != null && request.ProgramLogExerciseDTO.Weight != null)
                    {
                        var repScheme = new ProgramLogRepScheme()
                        {
                            ProgramLogExerciseId = programLogExerciseEntity.ProgramLogExerciseId,
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
