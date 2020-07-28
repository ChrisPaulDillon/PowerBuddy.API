using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Persistence;
using PowerLifting.LiftingStats.Repository;
using AutoMapper;

namespace PowerLifting.LiftingStats.Service
{
    public class LiftingStatsWrapper : ILiftingStatsWrapper
    {
        private ILiftingStatRepository _liftingStatRepo;
        private ILiftingStatAuditRepository _liftingStatAuditRepo;

        private readonly IMapper _mapper;

        private PowerLiftingContext _context;

        public LiftingStatsWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public ILiftingStatRepository LiftingStat
        {
            get
            {
                if (_liftingStatRepo == null)
                {
                    _liftingStatRepo = new LiftingStatRepository(_context, _mapper);
                }

                return _liftingStatRepo;
            }
        }

        public ILiftingStatAuditRepository LiftingStatAudit
        {
            get
            {
                if (_liftingStatAuditRepo == null)
                {
                    _liftingStatAuditRepo = new LiftingStatAuditRepository(_context, _mapper);
                }

                return _liftingStatAuditRepo;
            }
        }
    }
}
