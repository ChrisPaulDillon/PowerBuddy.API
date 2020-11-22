using System;
using AutoMapper;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class LiftingStatMappingProfile : Profile
    {
        public LiftingStatMappingProfile()
        {
            CreateMap<LiftingStatAudit, LiftFeedDTO>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.User.UserName))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId));

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId));

            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.Exercise, d => d.Ignore());


            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>().ReverseMap();
        }
    }
}
