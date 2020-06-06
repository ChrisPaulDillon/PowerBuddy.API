using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Exceptions;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.TemplatePrograms.Validators;
using PowerLifting.TemplatePrograms.Contracts.Services;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateProgramService : ITemplateProgramService
    {
        private readonly IMapper _mapper;
        private readonly ITemplateProgramWrapper _repo;
        private TemplateProgramValidator _validator;

        public TemplateProgramService(ITemplateProgramWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = new TemplateProgramValidator();
        }

        public async Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms()
        {
            return await _repo.TemplateProgram.GetAllTemplatePrograms();
        }

        public TemplateProgramDTO GetTemplateProgramById(int templateProgramId)
        {
            _validator.ValidateTemplateProgramId(templateProgramId);
            return _repo.TemplateProgram.GetTemplateProgramById(templateProgramId);
        }

        public TemplateProgramDTO GenerateProgramTemplateForIndividual(string userId, int programTemplateId, IEnumerable<LiftingStatDTO> liftingStats)
        {
            var templateProgram = _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);
            var tpExerciseCollection = _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(programTemplateId);

            var lsExerciseCount = liftingStats.Count(x => tpExerciseCollection.Any(i => i == x.ExerciseId));
            var tpExerciseCount = tpExerciseCollection.Count();

            if (lsExerciseCount != tpExerciseCount) //User does not have all the lifting stat filled out to create this program
            {
                throw new UserDoesNotHaveLiftingStatSetForExerciseException();
            }
            //var programmableExercises = GetProgrammableExercises()
            foreach (var templateWeek in templateProgram.TemplateWeeks)
                foreach (var templateDay in templateWeek.TemplateDays)
                    foreach (var templateExercise in templateDay.TemplateExercises)
                        foreach (var set in templateExercise.TemplateRepSchemes)
                        {
                            var percentage = set.Percentage / 100;
                            //if (templateExercise.ExerciseId == 1)
                            //set.WeightLifted = percentage * user.LiftingStats.SquatWeight;
                            //else if (templateExercise.ExerciseId == 26)
                            //set.WeightLifted = percentage * user.LiftingStats.DeadLiftWeight;
                            //else if (templateExercise.ExerciseId == 27)
                            //set.WeightLifted = percentage * user.LiftingStats.BenchWeight;
                        }

            var programTemplateDTO = _mapper.Map<TemplateProgramDTO>(templateProgram);
            return programTemplateDTO;
        }

        private IEnumerable<TemplateExercise> GetProgrammableExercises(IEnumerable<TemplateExercise> templateExercises)
        {
            return templateExercises.Where(x => x.Exercise.IsProgrammable);
        }

        public async Task CreateTemplateProgram(TemplateProgramDTO templateProgramDTO)
        {
            var isTaken = await _repo.TemplateProgram.DoesNameExist(templateProgramDTO.Name);
            if (isTaken) throw new TemplateProgramNameAlreadyExistsException();

            var newTemplateProgram = _mapper.Map<TemplateProgram>(templateProgramDTO);
            _repo.TemplateProgram.CreateTemplateProgram(newTemplateProgram);
        }
    }
}