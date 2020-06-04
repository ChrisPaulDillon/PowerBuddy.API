using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Persistence;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Repository;
using PowerLifting.TemplatePrograms.Contracts;

namespace PowerLifting.Systems.Service
{
    public class SystemWrapper : ISystemWrapper
    {
        private IExerciseRepository _exerciseRepo;
        private IExerciseTypeRepository _exerciseTypeRepo;
        private IExerciseMuscleGroupRepository _exerciseMuscleGroupRepo;
        private IRepSchemeTypeRepository _repSchemeTypeRepo;
        private ITemplateDifficultyRepository _templateDifficultyRepo;

        private PowerliftingContext _context;

        public SystemWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public ITemplateDifficultyRepository TemplateDifficulty
        {
            get
            {
                if (_templateDifficultyRepo == null)
                {
                    _templateDifficultyRepo = new TemplateDifficultyRepository(_context);
                }

                return _templateDifficultyRepo;
            }
        }

        public IExerciseRepository Exercise
        {
            get
            {
                if (_exerciseRepo == null)
                {
                    _exerciseRepo = new ExerciseRepository(_context);
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
                    _exerciseTypeRepo = new ExerciseTypeRepository(_context);
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
                    _exerciseMuscleGroupRepo = new ExerciseMuscleGroupRepository(_context);
                }

                return _exerciseMuscleGroupRepo;
            }
        }

        public IRepSchemeTypeRepository RepSchemeType
        {
            get
            {
                if (_repSchemeTypeRepo == null)
                {
                    _repSchemeTypeRepo = new RepSchemeTypeRepository(_context);
                }

                return _repSchemeTypeRepo;
            }
        }

    }
}
