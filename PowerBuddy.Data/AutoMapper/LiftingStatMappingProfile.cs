using System;
using AutoMapper;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class LiftingStatMappingProfile : Profile
    {
        public LiftingStatMappingProfile()
        {
            CreateMap<LiftingStatAudit, LiftFeedDto>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.User.UserName))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId));

            CreateMap<LiftingStatAudit, LiftingStatAuditDto>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId));

            CreateMap<LiftingStatAuditDto, LiftingStatAudit>()
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int>(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal>(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom<DateTime>(src => src.DateChanged))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.Exercise, d => d.Ignore())
                .ForMember(x => x.User, d => d.Ignore())
                .ForMember(x => x.WorkoutSet, d => d.Ignore());
        }
    }
}
