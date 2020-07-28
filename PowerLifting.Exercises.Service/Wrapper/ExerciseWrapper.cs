using AutoMapper;
using PowerLifting.Exercises.Repository;
using PowerLifting.Persistence;

namespace PowerLifting.Exercises.Service.Wrapper
{
    public class ExerciseWrapper : IExerciseWrapper
    {
        private IExerciseRepository _exerciseRepo;
        private IExerciseTypeRepository _exerciseTypeRepo;
        private IExerciseMuscleGroupRepository _exerciseMuscleGroupRepo;

        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public ExerciseWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public IExerciseRepository Exercise
        {
            get
            {
                if (_exerciseRepo == null)
                {
                    _exerciseRepo = new ExerciseRepository(_context, _mapper);
                }

                return _exerciseRepo;
            }
        }

        public IExerciseTypeRepository ExerciseType
        {
            get
            {
                if (_exerciseTypeRepo == null)
                {
                    _exerciseTypeRepo = new ExerciseTypeRepository(_context, _mapper);
                }

                return _exerciseTypeRepo;
            }
        }

        public IExerciseMuscleGroupRepository ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroupRepo == null)
                {
                    _exerciseMuscleGroupRepo = new ExerciseMuscleGroupRepository(_context, _mapper);
                }

                return _exerciseMuscleGroupRepo;
            }
        }
    }
}
