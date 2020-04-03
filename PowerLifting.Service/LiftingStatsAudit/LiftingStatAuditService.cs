using System;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.LiftingStatsAudit
{
    public class LiftingStatAuditService : ILiftingStatAuditService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public LiftingStatAuditService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
