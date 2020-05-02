using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStatsAudit.DTO;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.Service.LiftingStats.AutoMapper
{
    public class LiftingStatServiceMappingProfile : Profile
    {
        public LiftingStatServiceMappingProfile()
        {
            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

        }
    }
}
