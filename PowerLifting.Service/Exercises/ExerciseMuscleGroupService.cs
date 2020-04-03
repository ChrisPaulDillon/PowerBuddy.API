using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.Exercises
{
    public class ExerciseMuscleGroupService : IExerciseMuscleGroupService
    {
        private ConcurrentDictionary<int, ExerciseMuscleGroupDTO> _store;
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public ExerciseMuscleGroupService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, ExerciseMuscleGroupDTO>();
            _mapper = mapper;
        }

        public void DeleteExerciseType(ExerciseMuscleGroupDTO exerciseMuscleGroup)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseMuscleGroupDTO> GetAllExerciseMuscleGroups()
        {
            throw new NotImplementedException();
        }

        public Task<ExerciseMuscleGroupDTO> GetExerciseMuscleGroupById(int exerciseTypeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateExerciseType(ExerciseMuscleGroupDTO exerciseMuscleGroup)
        {
            throw new NotImplementedException();
        }
    }
}
