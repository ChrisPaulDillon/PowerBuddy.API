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
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.TemplatePrograms.Command.Admin;

namespace PowerLifting.MediatR.TemplatePrograms.CommandHandler.Admin
{
    public class CreateTemplateExerciseCollectionForTemplateCommandHandler : IRequestHandler<CreateTemplateExerciseCollectionForTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateTemplateExerciseCollectionForTemplateCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateTemplateExerciseCollectionForTemplateCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            //if (!isUserAdmin) throw new UnauthorisedUserException();

            var exercisesAlreadyExist = await _context.TemplateExerciseCollection.AsNoTracking().AnyAsync(x => x.TemplateProgramId == request.TemplateProgramId);

            if (exercisesAlreadyExist) return false;

            var templateProgram = await _context.TemplateProgram.ProjectTo<TemplateProgramExtendedDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.TemplateProgramId == request.TemplateProgramId, cancellationToken: cancellationToken);

            var exercisesToAdd = new List<int>();
            foreach (var week in templateProgram.TemplateWeeks)
            {
                foreach (var day in week.TemplateDays)
                {
                    foreach (var exercise in day.TemplateExercises)
                    {
                        if (!exercisesToAdd.Contains(exercise.ExerciseId))
                        {
                            exercisesToAdd.Add(exercise.ExerciseId);
                        }
                    }
                }
            }

            var templateExerciseCollections = exercisesToAdd.Select(exerciseId => new TemplateExerciseCollection() { ExerciseId = exerciseId, TemplateProgramId = request.TemplateProgramId }).ToList();

            _context.TemplateExerciseCollection.AddRange(templateExerciseCollections);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}