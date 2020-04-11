using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using Powerlifting.Service.TemplatePrograms.DTO;
using Powerlifting.Service.TemplatePrograms.Model;
using Powerlifting.Services.TemplatePrograms;

namespace PowerLifting.Service.TemplatePrograms
{
    public class TemplateProgramService : ITemplateProgramService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public TemplateProgramService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopLevelTemplateProgramDTO>> GetAllTemplatePrograms()
        {
            var programTemplates = await _repo.TemplateProgram.GetAllTemplatePrograms();
            var programTemplateDTO = _mapper.Map<IEnumerable<TopLevelTemplateProgramDTO>>(programTemplates);
            return programTemplateDTO;
        }

        public async Task<TemplateProgramDTO> GetTemplateProgramById(int programTemplateId)
        {
            //var user = await _repo.User.get(programTemplateId);
            TemplateProgram programTemplate = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);
            var programTemplateDTO = _mapper.Map<TemplateProgramDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<TemplateProgramDTO> GenerateProgramTemplateForIndividual(string userId, int programTemplateId)
        {
            var user = await _repo.User.GetUserByIdIncludeLiftingStats(userId);
            var programTemplate = await _repo.TemplateProgram.GetTemplateProgramById(programTemplateId);

            foreach (var exercise in programTemplate.TemplateExercises)
            {
                foreach (var set in exercise.TemplateRepSchemes)
                {
                    var percentage = (double)set.Percentage / 100;
                    if (exercise.ExerciseName == "Squat")
                    {
                        set.WeightLifted =  percentage * user.LiftingStats.SquatWeight;
                    }
                    else if (exercise.ExerciseName == "Deadlift")
                    {
                        set.WeightLifted =  percentage * user.LiftingStats.DeadliftWeight;
                    }
                    else if (exercise.ExerciseName == "Bench Press")
                    {
                        set.WeightLifted = percentage * user.LiftingStats.BenchWeight;
                    }
                }
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
            throw new System.NotImplementedException();
        }
    }
}
