using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Repositories;
using PowerLifting.Systems.Repository;

namespace PowerLifting.Systems.Service
{
    public class SystemWrapper : ISystemWrapper
    {
        private IExerciseRepository _exerciseRepo;
        private IExerciseTypeRepository _exerciseTypeRepo;
        private IExerciseMuscleGroupRepository _exerciseMuscleGroupRepo;
        private IRepSchemeTypeRepository _repSchemeTypeRepo;
        private ITemplateDifficultyRepository _templateDifficultyRepo;
        private IQuoteRepository _quoteRepo;

        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;
        public SystemWrapper(PowerliftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public ITemplateDifficultyRepository TemplateDifficulty
        {
            get
            {
                if (_templateDifficultyRepo == null)
                {
                    _templateDifficultyRepo = new TemplateDifficultyRepository(_context, _mapper);
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

        public IRepSchemeTypeRepository RepSchemeType
        {
            get
            {
                if (_repSchemeTypeRepo == null)
                {
                    _repSchemeTypeRepo = new RepSchemeTypeRepository(_context, _mapper);
                }

                return _repSchemeTypeRepo;
            }
        }

        public IQuoteRepository Quote
        {
            get
            {
                if (_quoteRepo == null)
                {
                    _quoteRepo = new QuoteRepository(_context, _mapper);
                }

                return _quoteRepo;
            }
        }
    }
}
