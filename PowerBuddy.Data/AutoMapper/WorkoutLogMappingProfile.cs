using System;
using System.Linq;
using AutoMapper;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class WorkoutLogMappingProfile : Profile
    {
        public WorkoutLogMappingProfile()
        {

            CreateMap<WorkoutLog, WorkoutLogStatDTO>()
                .ForMember(x => x.WorkoutLogId, d => d.MapFrom<int>(src => src.WorkoutLogId))
                .ForMember(x => x.CustomName, d => d.MapFrom<string>(src => src.CustomName))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
                .ForMember(x => x.NoOfWeeks, d => d.MapFrom<int>(src => (int)src.WorkoutDays.Max(x => x.WeekNo)))
                .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.WorkoutDays.OrderBy(x => x.Date).FirstOrDefault().Date))
                .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.WorkoutDays.OrderByDescending(x => x.Date).FirstOrDefault().Date))
                .ForMember(x => x.Monday, d => d.MapFrom<bool>(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom<bool>(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom<bool>(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom<bool>(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom<bool>(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom<bool>(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom<bool>(src => src.Sunday))
                .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays.OrderBy(x => x.WeekNo)))
                .ForMember(x => x.TemplateName, d => d.MapFrom<string>(src => src.TemplateProgram.Name))
                .ForMember(x => x.DayCount, d => d.MapFrom(src => src.WorkoutDays.Count()))
                .ForMember(x => x.ExerciseCount, d => d.MapFrom(src => src.WorkoutDays.SelectMany(p => p.WorkoutExercises).Count()));


            CreateMap<WorkoutLog, WorkoutLogDTO>()
             .ForMember(x => x.WorkoutLogId, d => d.MapFrom<int>(src => src.WorkoutLogId))
             .ForMember(x => x.CustomName, d => d.MapFrom<string>(src => src.CustomName))
             .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
             .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
             .ForMember(x => x.NoOfWeeks, d => d.MapFrom<int>(src => (int)src.WorkoutDays.Max(x => x.WeekNo)))
             .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.WorkoutDays.OrderBy(x => x.Date).FirstOrDefault().Date))
             .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.WorkoutDays.OrderByDescending(x => x.Date).FirstOrDefault().Date))
             .ForMember(x => x.Monday, d => d.MapFrom<bool>(src => src.Monday))
             .ForMember(x => x.Tuesday, d => d.MapFrom<bool>(src => src.Tuesday))
             .ForMember(x => x.Wednesday, d => d.MapFrom<bool>(src => src.Wednesday))
             .ForMember(x => x.Thursday, d => d.MapFrom<bool>(src => src.Thursday))
             .ForMember(x => x.Friday, d => d.MapFrom<bool>(src => src.Friday))
             .ForMember(x => x.Saturday, d => d.MapFrom<bool>(src => src.Saturday))
             .ForMember(x => x.Sunday, d => d.MapFrom<bool>(src => src.Sunday))
             .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays.OrderBy(x => x.WeekNo)))
             .ForMember(x => x.TemplateName, d => d.MapFrom<string>(src => src.TemplateProgram.Name));

            CreateMap<WorkoutLogDTO, WorkoutLog>()
                .ForMember<int>(x => x.WorkoutLogId, d => d.MapFrom(src => src.WorkoutLogId))
                .ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<int?>(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
                .ForMember<bool>(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember<bool>(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember<bool>(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember<bool>(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember<bool>(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember<bool>(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember<bool>(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays.OrderBy(x => x.Date)))
                .ForMember(x => x.TemplateProgram, opt => opt.Ignore());

            CreateMap<WorkoutLogInputScratchDTO, WorkoutLog>()
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName))
                .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays))
                .ForMember(x => x.Monday, d => d.Ignore())
                .ForMember(x => x.Tuesday, d => d.Ignore())
                .ForMember(x => x.Wednesday, d => d.Ignore())
                .ForMember(x => x.Thursday, d => d.Ignore())
                .ForMember(x => x.Friday, d => d.Ignore())
                .ForMember(x => x.Saturday, d => d.Ignore())
                .ForMember(x => x.Sunday, d => d.Ignore())
                .ForMember(x => x.TemplateProgramId, d => d.Ignore())
                .ForMember(x => x.WorkoutLogId, d => d.Ignore())
                .ForMember(x => x.TemplateProgram, d => d.Ignore());

            CreateMap<WorkoutLogTemplateInputDTO, WorkoutLog>()
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<int?>(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId))
                .ForMember<bool>(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember<bool>(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember<bool>(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember<bool>(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember<bool>(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember<bool>(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember<bool>(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.CustomName, d => d.MapFrom(src => src.CustomName))
                .ForMember(x => x.WorkoutLogId, d => d.Ignore())
                .ForMember(x => x.TemplateProgram, d => d.Ignore())
                .ForMember(x => x.WorkoutDays, d => d.Ignore());

        }
    }
}
