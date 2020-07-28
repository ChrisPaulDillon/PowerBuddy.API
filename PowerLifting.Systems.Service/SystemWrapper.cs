using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.Systems.Repository;

namespace PowerLifting.Systems.Service
{
    public class SystemWrapper : ISystemWrapper
    {
        private IRepSchemeTypeRepository _repSchemeTypeRepo;
        private ITemplateDifficultyRepository _templateDifficultyRepo;
        private IQuoteRepository _quoteRepo;

        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public SystemWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
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
