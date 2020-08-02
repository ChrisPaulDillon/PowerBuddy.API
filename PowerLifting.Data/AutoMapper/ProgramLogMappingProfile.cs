﻿using AutoMapper;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.Data.AutoMapper
{
    public class ProgramLogMappingProfile : Profile
    {
        public ProgramLogMappingProfile()
        {
            CreateMap<ProgramLog, ProgramLogDTO>()
                .ForMember(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId))
                .ForMember(x => x.NoOfWeeks, d => d.MapFrom(src => src.NoOfWeeks))
                .ForMember(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
                .ForMember(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ForMember(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.Active, d => d.MapFrom(src => src.Active))
                .ReverseMap();

            CreateMap<ProgramLog, ProgramLogStatDTO>()
                .ForMember(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId))
                .ForMember(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ReverseMap();

            CreateMap<ProgramLog, CProgramLogDTO>()
                .ForMember(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
                .ForMember(x => x.Active, d => d.MapFrom(src => src.Active))
                .ForMember(dest => dest.DayCount, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProgramLogWeek, ProgramLogWeekDTO>()
                .ForMember(x => x.ProgramLogWeekId, d => d.MapFrom(src => src.ProgramLogWeekId))
                .ForMember(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.WeekNo, d => d.MapFrom(src => src.WeekNo))
                .ForMember(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
                .ForMember(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ReverseMap();

            CreateMap<ProgramLogDay, ProgramLogDayDTO>()
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom(src => src.ProgramLogDayId))
                .ForMember(x => x.ProgramLogWeekId, d => d.MapFrom(src => src.ProgramLogWeekId))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember(x => x.PersonalBest, d => d.MapFrom(src => src.PersonalBest))
                .ReverseMap();

            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>()
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom(src => src.ProgramLogExerciseId))
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom(src => src.ProgramLogDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.NoOfSets))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.PersonalBest, d => d.MapFrom(src => src.PersonalBest))
                .ReverseMap();

            CreateMap<ProgramLogExercise, CProgramLogExerciseDTO>()
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom(src => src.ProgramLogDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.NoOfSets))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(dest => dest.RepSchemeType, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProgramLogRepScheme, ProgramLogRepSchemeDTO>()
                .ForMember(x => x.ProgramLogRepSchemeId, d => d.MapFrom(src => src.ProgramLogRepSchemeId))
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom(src => src.ProgramLogExerciseId))
                .ForMember(x => x.SetNo, d => d.MapFrom(src => src.SetNo))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom(src => src.WeightLifted))
                .ForMember(x => x.Percentage, d => d.MapFrom(src => src.Percentage))
                .ForMember(x => x.PersonalBest, d => d.MapFrom(src => src.PersonalBest))
                .ForMember(x => x.AMRAP, d => d.MapFrom(src => src.AMRAP))
                .ForMember(x => x.RepsCompleted, d => d.MapFrom(src => src.RepsCompleted))
                .ReverseMap();
        }
    }
}
