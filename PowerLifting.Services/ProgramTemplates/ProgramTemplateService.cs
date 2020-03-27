using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Powerlifting.Services.ProgramTemplates.DTO;
using PowerLifting.Repositorys.RepositoryWrappers;
using Powerlifting.Services.ProgramTemplates.Model;

namespace Powerlifting.Services.ProgramTemplates
{
    public class ProgramTemplateService : IProgramTemplateService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ProgramTemplateService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopLevelProgramTemplateDTO>> GetAllProgramTemplates()
        {
            var programTemplates = await _repo.ProgramTemplate.GetAllProgramTemplates();
            var programTemplateDTO = _mapper.Map<IEnumerable<TopLevelProgramTemplateDTO>>(programTemplates);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateById(int programTemplateId)
        {
            //var user = await _repo.User.get(programTemplateId);
            ProgramTemplate programTemplate = await _repo.ProgramTemplate.GetProgramTemplateById(programTemplateId);
            foreach (var exercise in programTemplate.ProgramExercises)
            {
                foreach(var set in exercise.IndividualSets)
                {
                    //set.WeightLifted = exercise.Percentage
                }
            }
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateByIdIncludeLiftingStats(int userId, int programTemplateId)
        {
            var user = await _repo.User.GetUserByIdIncludeLiftingStats(userId);
            var programTemplate = await _repo.ProgramTemplate.GetProgramTemplateById(programTemplateId);

            foreach (var exercise in programTemplate.ProgramExercises)
            {
                foreach (var set in exercise.IndividualSets)
                {
                    if (exercise.ExerciseName == "Squat")
                    {
                        double percentage =  exercise.Percentage / 100;
                        set.WeightLifted = percentage * user.LiftingStats.SquatWeight;
                    }
                    else if (exercise.ExerciseName == "Deadlift")
                    {
                        set.WeightLifted = (exercise.Percentage / 100) * user.LiftingStats.DeadliftWeight;
                    }
                    else if (exercise.ExerciseName == "Bench Press")
                    {
                        set.WeightLifted = (exercise.Percentage / 100) * user.LiftingStats.BenchWeight;
                    }
                }
            }
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public async Task<ProgramTemplateDTO> GetProgramTemplateByName(string programName)
        {
            var programTemplate = await _repo.ProgramTemplate.GetProgramTemplateByName(programName);
            var programTemplateDTO = _mapper.Map<ProgramTemplateDTO>(programTemplate);
            return programTemplateDTO;
        }

        public Task<ProgramTemplateDTO> CreateProgramTemplate(ProgramTemplateDTO programType)
        {
            throw new System.NotImplementedException();
        }
    }
}
