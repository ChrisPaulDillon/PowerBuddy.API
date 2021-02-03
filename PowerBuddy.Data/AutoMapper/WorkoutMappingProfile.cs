using AutoMapper;
using System;
using System.Linq;
using PowerBuddy.Data.DTOs.ProgramLogs.Workouts;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class WorkoutMappingProfile : Profile
    {
        public WorkoutMappingProfile()
        {
            //into dto
            CreateMap<WorkoutTemplate, WorkoutTemplateDTO>()
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.WorkoutName, d => d.MapFrom(src => src.WorkoutName))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.DateCreated, d => d.MapFrom(src => src.DateCreated))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises));

            //into entity
            CreateMap<WorkoutTemplateDTO, WorkoutTemplate>()
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.WorkoutName, d => d.MapFrom(src => src.WorkoutName))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.DateCreated, d => d.MapFrom(src => src.DateCreated))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises));

            //into entity
            CreateMap<WorkoutDayDTO, WorkoutDay>()
                .ForMember<int>(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember<int?>(x => x.WorkoutLogId, d => d.MapFrom(src => src.WorkoutLogId))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<DateTime>(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember<bool>(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises))
                .ForMember(x => x.WorkoutLog, d => d.Ignore())
                .ForMember(x => x.User, d => d.Ignore());

            //into dto
            CreateMap<WorkoutDay, WorkoutDayDTO>()
                .ForMember(x => x.WorkoutDayId, d => d.MapFrom<int>(src => src.WorkoutDayId))
                .ForMember(x => x.WorkoutLogId, d => d.MapFrom<int?>(src => src.WorkoutLogId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.Date, d => d.MapFrom<DateTime>(src => src.Date))
                .ForMember(x => x.Completed, d => d.MapFrom<bool>(src => src.Completed))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises))
                .ForMember(x => x.TemplateName, d => d.MapFrom(src => src.WorkoutLog.CustomName))
                .ForMember(x => x.UsingMetric, d => d.MapFrom(src => src.User.UserSetting.UsingMetric));
        }
    }
}
