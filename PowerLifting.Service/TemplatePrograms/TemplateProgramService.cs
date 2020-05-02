using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Exceptions;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms
{
    public class TemplateProgramService : ITemplateProgramService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public TemplateProgramService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateProgramDTO>> GetAllTemplatePrograms()
        {
            var programTemplates = await _repo.TemplateProgram.GetAllTemplatePrograms();
            var programTemplateDTO = _mapper.Map<IEnumerable<TemplateProgramDTO>>(programTemplates);
            return programTemplateDTO;
        }

        public async Task<TemplateProgramDTO> GetTemplateProgramById(int programTemplateId)
        {
            //var user = await _repo.User.get(programTemplateId);
            var programTemplate = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);
            var programTemplateDTO = _mapper.Map<TemplateProgramDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<TemplateProgramDTO> GenerateProgramTemplateForIndividual(string userId, int programTemplateId)
        {
            var liftingStats1RM = await _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, 1);
            var templateProgram = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);
            var tpExerciseCollection = await _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(programTemplateId);

            var lsExerciseCount = liftingStats1RM.Where(x => tpExerciseCollection.Any(i => i == x.ExerciseId)).Count();
            var tpExerciseCount = tpExerciseCollection.Count();

            if(lsExerciseCount != tpExerciseCount) //User does not have all the lifting stat filled out to create this program
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
            var isTaken = await _repo.TemplateProgram.GetTemplateProgramByName(templateProgramDTO.Name);
            if(isTaken) throw new TemplateProgramNameAlreadyExistsException();

            var newTemplateProgram = _mapper.Map<TemplateProgram>(templateProgramDTO);
            _repo.TemplateProgram.CreateTemplateProgram(newTemplateProgram);
        }
    }
}