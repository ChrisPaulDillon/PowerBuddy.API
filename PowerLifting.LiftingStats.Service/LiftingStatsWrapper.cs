using PowerLifting.LiftingStats.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Persistence;
using PowerLifting.LiftingStats.Repository;

namespace PowerLifting.LiftingStats.Service
{
    public class LiftingStatsWrapper : ILiftingStatsWrapper
    {
        private ILiftingStatRepository _liftingStatRepo;
        private ILiftingStatAuditRepository _liftingStatAuditRepo;


        private PowerliftingContext _context;

        public LiftingStatsWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public ILiftingStatRepository LiftingStat
        {
            get
            {
                if (_liftingStatRepo == null)
                {
                    _liftingStatRepo = new LiftingStatRepository(_context);
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
                    _liftingStatAuditRepo = new LiftingStatAuditRepository(_context);
                }

                return _liftingStatAuditRepo;
            }
        }
    }
}
