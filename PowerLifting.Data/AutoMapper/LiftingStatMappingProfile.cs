using AutoMapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.AutoMapper
{
    public class LiftingStatMappingProfile : Profile
    {
        public LiftingStatMappingProfile()
        {
            CreateMap<LiftingStatAudit, LiftFeedDTO>()
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.User.UserName))
                .ForMember(x => x.RepRange, d => d.MapFrom(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ReverseMap();

            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

        }
    }
}
