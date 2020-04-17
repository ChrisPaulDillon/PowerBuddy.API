using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.TemplatePrograms.DTO;

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
            var user = await _repo.User.GetUserByIdIncludeLiftingStats(userId);
            var programTemplate = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);

            foreach (var templateWeek in programTemplate.TemplateWeeks)
            foreach (var templateDay in templateWeek.TemplateDays)
            foreach (var templateExercise in templateDay.TemplateExercises)
            foreach (var set in templateExercise.TemplateRepSchemes)
            {
                var percentage = set.Percentage / 100;
                if (templateExercise.ExerciseName == "Squat")
                    set.WeightLifted = percentage * user.LiftingStats.SquatWeight;
                else if (templateExercise.ExerciseName == "Deadlift")
                    set.WeightLifted = percentage * user.LiftingStats.DeadliftWeight;
                else if (templateExercise.ExerciseName == "Bench Press")
                    set.WeightLifted = percentage * user.LiftingStats.BenchWeight;
            }

            var programTemplateDTO = _mapper.Map<TemplateProgramDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<TemplateProgramDTO> GetTemplateProgramByName(string programName)
        {
            var programTemplate = await _repo.TemplateProgram.GetTemplateProgramByName(programName);
            var programTemplateDTO = _mapper.Map<TemplateProgramDTO>(programTemplate);
            return programTemplateDTO;
        }

        public Task<TemplateProgramDTO> CreateTemplateProgram(TemplateProgramDTO programType)
        {
            throw new NotImplementedException();
        }
    }
}