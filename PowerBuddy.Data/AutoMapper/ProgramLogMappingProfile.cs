using System;
using System.Linq;
using AutoMapper;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class ProgramLogMappingProfile : Profile
    {
        public ProgramLogMappingProfile()
        {
            CreateMap<ProgramLog, ProgramLogDTO>()
                .ForMember(x => x.ProgramLogId, d => d.MapFrom<int>(src => src.ProgramLogId))
                .ForMember(x => x.CustomName, d => d.MapFrom<string>(src => src.CustomName))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
                .ForMember(x => x.NoOfWeeks, d => d.MapFrom<int>(src => src.NoOfWeeks))
                .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.StartDate))
                .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.EndDate))
                .ForMember(x => x.Monday, d => d.MapFrom<bool>(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom<bool>(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom<bool>(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom<bool>(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom<bool>(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom<bool>(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom<bool>(src => src.Sunday))
                .ForMember(x => x.ProgramLogWeeks, d => d.MapFrom(src => src.ProgramLogWeeks.OrderBy<ProgramLogWeek, int>(x => x.WeekNo)))
                .ForMember(x => x.TemplateName, d => d.MapFrom<string>(src => src.TemplateProgram.Name))
                .ForMember(x => x.LogDates, opt => opt.Ignore());

            CreateMap<ProgramLogDTO, ProgramLog>().ForMember<int>(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId)).ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName)).ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId)).ForMember<int?>(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0)).ForMember<int>(x => x.NoOfWeeks, d => d.MapFrom(src => src.NoOfWeeks)).ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate)).ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate)).ForMember<bool>(x => x.Monday, d => d.MapFrom(src => src.Monday)).ForMember<bool>(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday)).ForMember<bool>(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday)).ForMember<bool>(x => x.Thursday, d => d.MapFrom(src => src.Thursday)).ForMember<bool>(x => x.Friday, d => d.MapFrom(src => src.Friday)).ForMember<bool>(x => x.Saturday, d => d.MapFrom(src => src.Saturday)).ForMember<bool>(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.ProgramLogWeeks, d => d.MapFrom(src => src.ProgramLogWeeks.OrderBy(x => x.WeekNo)))
                .ForMember(x => x.TemplateProgram, opt => opt.Ignore());

            CreateMap<ProgramLog, ProgramLogStatDTO>()
                .ForMember(x => x.ProgramLogId, d => d.MapFrom<int>(src => src.ProgramLogId))
                .ForMember(x => x.CustomName, d => d.MapFrom<string>(src => src.CustomName))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
                .ForMember(x => x.TemplateName, d => d.MapFrom<string>(src => src.TemplateProgram.Name))
                .ForMember(x => x.NoOfWeeks, d => d.MapFrom<int>(src => src.NoOfWeeks))
                .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.StartDate))
                .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.EndDate))
                .ForMember(x => x.Monday, d => d.MapFrom<bool>(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom<bool>(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom<bool>(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom<bool>(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom<bool>(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom<bool>(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom<bool>(src => src.Sunday))
                .ForMember(x => x.ProgramLogWeeks, d => d.MapFrom(src => src.ProgramLogWeeks.OrderBy<ProgramLogWeek, int>(x => x.WeekNo)))
                .ForMember(x => x.DayCount, opt => opt.Ignore())
                .ForMember(x => x.ExerciseCount, opt => opt.Ignore())
                .ForMember(x => x.ExerciseCompletedCount, opt => opt.Ignore())
                .ForMember(x => x.ExerciseVarianceCount, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProgramLogInputScratchDTO, ProgramLog>().ForMember<int>(x => x.NoOfWeeks, d => d.MapFrom(src => src.NoOfWeeks)).ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId)).ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName)).ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate)).ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ForMember(x => x.ProgramLogWeeks, d => d.MapFrom(src => src.ProgramLogWeeks))
                .ForMember(x => x.TemplateProgram, d => d.Ignore());

            CreateMap<ProgramLogTemplateInputDTO, ProgramLog>().ForMember<int>(x => x.NoOfWeeks, d => d.MapFrom(src => src.NoOfWeeks)).ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId)).ForMember<int?>(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId)).ForMember<bool>(x => x.Monday, d => d.MapFrom(src => src.Monday)).ForMember<bool>(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday)).ForMember<bool>(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday)).ForMember<bool>(x => x.Thursday, d => d.MapFrom(src => src.Thursday)).ForMember<bool>(x => x.Friday, d => d.MapFrom(src => src.Friday)).ForMember<bool>(x => x.Saturday, d => d.MapFrom(src => src.Saturday)).ForMember<bool>(x => x.Sunday, d => d.MapFrom(src => src.Sunday)).ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate)).ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate)).ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ForMember(x => x.TemplateProgram, d => d.Ignore());

            //into entity
            CreateMap<ProgramLogWeekDTO, ProgramLogWeek>().ForMember<int>(x => x.ProgramLogWeekId, d => d.MapFrom(src => src.ProgramLogWeekId)).ForMember<int>(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId)).ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId)).ForMember<int>(x => x.WeekNo, d => d.MapFrom(src => src.WeekNo)).ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate)).ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ForMember(x => x.ProgramLogDays, d => d.MapFrom(src => src.ProgramLogDays));

            //into dto
            CreateMap<ProgramLogWeek, ProgramLogWeekDTO>()
                .ForMember(x => x.ProgramLogWeekId, d => d.MapFrom<int>(src => src.ProgramLogWeekId))
                .ForMember(x => x.ProgramLogId, d => d.MapFrom<int>(src => src.ProgramLogId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.WeekNo, d => d.MapFrom<int>(src => src.WeekNo))
                .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.StartDate))
                .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.EndDate))
                .ForMember(x => x.ProgramLogDays, d => d.MapFrom(src => src.ProgramLogDays.OrderBy<ProgramLogDay, DateTime>(x => x.Date)));

            //into entity
            CreateMap<ProgramLogDayDTO, ProgramLogDay>()
                .ForMember<int>(x => x.ProgramLogDayId, d => d.MapFrom(src => src.ProgramLogDayId))
                .ForMember<int>(x => x.ProgramLogWeekId, d => d.MapFrom(src => src.ProgramLogWeekId))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<DateTime>(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember<bool>(x => x.Completed, d => d.MapFrom(src => src.Completed));

            //into dto
            CreateMap<ProgramLogDay, ProgramLogDayDTO>()
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom<int>(src => src.ProgramLogDayId))
                .ForMember(x => x.ProgramLogWeekId, d => d.MapFrom<int>(src => src.ProgramLogWeekId))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.Date, d => d.MapFrom<DateTime>(src => src.Date))
                .ForMember(x => x.Completed, d => d.MapFrom<bool>(src => src.Completed));

            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>()
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom<int>(src => src.ProgramLogExerciseId))
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom<int>(src => src.ProgramLogDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.NoOfSets, d => d.MapFrom<int>(src => src.NoOfSets))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.ProgramLogExerciseTonnageId, d => d.MapFrom<int>(src => src.ProgramLogExerciseTonnageId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseTonnage, d => d.MapFrom<decimal>(src => src.ProgramLogExerciseTonnage.ExerciseTonnage))
                .ForMember(x => x.ProgramLogRepSchemes, d => d.MapFrom(src => src.ProgramLogRepSchemes.OrderBy<ProgramLogRepScheme, decimal>(x => x.WeightLifted)));

            //into dto
            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>()
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom<int>(src => src.ProgramLogExerciseId))
                .ForMember(x => x.ProgramLogDayId, d => d.MapFrom<int>(src => src.ProgramLogDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.NoOfSets, d => d.MapFrom<int>(src => src.NoOfSets))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.ProgramLogExerciseTonnageId, d => d.MapFrom<int>(src => src.ProgramLogExerciseTonnageId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseTonnage, d => d.MapFrom<decimal>(src => src.ProgramLogExerciseTonnage.ExerciseTonnage));

            //into entity
            CreateMap<ProgramLogExerciseDTO, ProgramLogExercise>()
                .ForMember<int>(x => x.ProgramLogExerciseId, d => d.MapFrom(src => src.ProgramLogExerciseId))
                .ForMember<int>(x => x.ProgramLogDayId, d => d.MapFrom(src => src.ProgramLogDayId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember<int>(x => x.NoOfSets, d => d.MapFrom(src => src.NoOfSets))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<int>(x => x.ProgramLogExerciseTonnageId, d => d.MapFrom(src => src.ProgramLogExerciseTonnageId))
                .ForMember(x => x.ProgramLogExerciseTonnage, d => d.MapFrom(src => src.ProgramLogExerciseTonnageDTO))
                .ForMember(x => x.Exercise, d => d.Ignore());

            CreateMap<ProgramLogExerciseTonnage, ProgramLogExerciseTonnageDTO>()
                .ForMember(x => x.ProgramLogExerciseTonnageId, d => d.MapFrom<int>(src => src.ProgramLogExerciseTonnageId))
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom<int>(src => src.ProgramLogExerciseId))
                .ForMember(x => x.ExerciseTonnage, d => d.MapFrom<decimal>(src => src.ExerciseTonnage))
                .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ReverseMap();

            CreateMap<ProgramLogRepScheme, ProgramLogRepSchemeDTO>()
                .ForMember(x => x.ProgramLogRepSchemeId, d => d.MapFrom<int>(src => src.ProgramLogRepSchemeId))
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom<int>(src => src.ProgramLogExerciseId))
                .ForMember(x => x.SetNo, d => d.MapFrom<int>(src => src.SetNo))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.Percentage, d => d.MapFrom<decimal?>(src => src.Percentage))
                .ForMember(x => x.PersonalBest, d => d.MapFrom<bool?>(src => src.PersonalBest))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
                .ForMember(x => x.RepsCompleted, d => d.MapFrom<int>(src => src.RepsCompleted ?? src.NoOfReps)) //default to noOfReps if not been touched
                .ReverseMap();

            CreateMap<ProgramLogRepScheme, CProgramLogRepSchemeDTO>()
                .ForMember(x => x.SetNo, d => d.MapFrom<int>(src => src.SetNo))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.Percentage, d => d.MapFrom<decimal?>(src => src.Percentage))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
               .ReverseMap();
        }
    }
}
