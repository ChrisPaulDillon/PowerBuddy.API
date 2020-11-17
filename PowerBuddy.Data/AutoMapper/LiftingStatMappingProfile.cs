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
                .ForMember(x => x.LiftingStatId, d => d.MapFrom<int>(src => src.LiftingStatId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId ?? 0));

            CreateMap<LiftingStat, LiftingStatDTO>()
                .ForMember(x => x.LiftingStatId, d => d.MapFrom<int>(src => src.LiftingStatId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.RepRange, d => d.MapFrom<int>(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom<decimal?>(src => src.Weight))
                .ForMember(x => x.GoalWeight, d => d.MapFrom<decimal?>(src => src.GoalWeight))
                .ForMember(x => x.PercentageToGoal, d => d.MapFrom<decimal?>(src => src.PercentageToGoal))
                .ForMember(x => x.LastUpdated, d => d.MapFrom<DateTime?>(src => src.LastUpdated))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName));

            CreateMap<LiftingStatDTO, LiftingStat>().ForMember<int>(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId)).ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId)).ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId)).ForMember<int>(x => x.RepRange, d => d.MapFrom(src => src.RepRange)).ForMember<decimal?>(x => x.Weight, d => d.MapFrom(src => src.Weight)).ForMember<decimal?>(x => x.GoalWeight, d => d.MapFrom(src => src.GoalWeight)).ForMember<decimal?>(x => x.PercentageToGoal, d => d.MapFrom(src => src.PercentageToGoal)).ForMember<DateTime?>(x => x.LastUpdated, d => d.MapFrom(src => src.LastUpdated))
                .ForMember(x => x.Exercise, d => d.Ignore());

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

        }
    }
}
