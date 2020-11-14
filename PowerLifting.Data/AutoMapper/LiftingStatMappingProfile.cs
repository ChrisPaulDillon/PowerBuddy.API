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
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom(src => src.LiftingStatAuditId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.UserName, d => d.MapFrom(src => src.User.UserName))
                .ForMember(x => x.RepRange, d => d.MapFrom(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom(src => src.Weight))
                .ForMember(x => x.DateChanged, d => d.MapFrom(src => src.DateChanged))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ForMember(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId ?? 0));

            CreateMap<LiftingStat, LiftingStatDTO>()
                .ForMember(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.RepRange, d => d.MapFrom(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom(src => src.Weight))
                .ForMember(x => x.GoalWeight, d => d.MapFrom(src => src.GoalWeight))
                .ForMember(x => x.PercentageToGoal, d => d.MapFrom(src => src.PercentageToGoal))
                .ForMember(x => x.LastUpdated, d => d.MapFrom(src => src.LastUpdated))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName));

            CreateMap<LiftingStatDTO, LiftingStat>()
                .ForMember(x => x.LiftingStatId, d => d.MapFrom(src => src.LiftingStatId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.RepRange, d => d.MapFrom(src => src.RepRange))
                .ForMember(x => x.Weight, d => d.MapFrom(src => src.Weight))
                .ForMember(x => x.GoalWeight, d => d.MapFrom(src => src.GoalWeight))
                .ForMember(x => x.PercentageToGoal, d => d.MapFrom(src => src.PercentageToGoal))
                .ForMember(x => x.LastUpdated, d => d.MapFrom(src => src.LastUpdated))
                .ForMember(x => x.Exercise, d => d.Ignore());

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

        }
    }
}
