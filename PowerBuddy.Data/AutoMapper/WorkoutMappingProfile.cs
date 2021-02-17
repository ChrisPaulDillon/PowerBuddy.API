using AutoMapper;
using System;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class WorkoutMappingProfile : Profile
    {
        public WorkoutMappingProfile()
        {
            //into entity
            CreateMap<WorkoutDayDto, WorkoutDay>()
                .ForMember<int>(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember<int?>(x => x.WorkoutLogId, d => d.MapFrom(src => src.WorkoutLogId))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<DateTime>(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember<bool>(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises))
                .ForMember(x => x.WorkoutLog, d => d.Ignore())
                .ForMember(x => x.User, d => d.Ignore());

            //into Dto
            CreateMap<WorkoutDay, WorkoutDayDto>()
	            .ForMember(x => x.WorkoutDayId, d => d.MapFrom<int>(src => src.WorkoutDayId))
	            .ForMember(x => x.WorkoutLogId, d => d.MapFrom<int?>(src => src.WorkoutLogId))
	            .ForMember(x => x.UserName, d => d.MapFrom<string>(src => src.User.UserName))
	            .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
	            .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
	            .ForMember(x => x.Date, d => d.MapFrom<DateTime>(src => src.Date))
	            .ForMember(x => x.Completed, d => d.MapFrom<bool>(src => src.Completed))
	            .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises))
				.ForMember(x => x.TemplateName, d => d.MapFrom(src => src.WorkoutLog.CustomName))
				.ForMember(x => x.UsingMetric, d => d.MapFrom<bool>(src => src.User.UserSetting.UsingMetric));
        }
    }
}
