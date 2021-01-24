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

            CreateMap<WorkoutLog, WorkoutLogDTO>()
             .ForMember(x => x.WorkoutLogId, d => d.MapFrom<int>(src => src.WorkoutLogId))
             .ForMember(x => x.CustomName, d => d.MapFrom<string>(src => src.CustomName))
             .ForMember(x => x.UserId, d => d.MapFrom<string>(src => src.UserId))
             .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
             .ForMember(x => x.NoOfWeeks, d => d.MapFrom<int>(src => (int)src.WorkoutDays.Max(x => x.WeekNo)))
             .ForMember(x => x.StartDate, d => d.MapFrom<DateTime>(src => src.StartDate))
             .ForMember(x => x.EndDate, d => d.MapFrom<DateTime>(src => src.EndDate))
             .ForMember(x => x.Monday, d => d.MapFrom<bool>(src => src.Monday))
             .ForMember(x => x.Tuesday, d => d.MapFrom<bool>(src => src.Tuesday))
             .ForMember(x => x.Wednesday, d => d.MapFrom<bool>(src => src.Wednesday))
             .ForMember(x => x.Thursday, d => d.MapFrom<bool>(src => src.Thursday))
             .ForMember(x => x.Friday, d => d.MapFrom<bool>(src => src.Friday))
             .ForMember(x => x.Saturday, d => d.MapFrom<bool>(src => src.Saturday))
             .ForMember(x => x.Sunday, d => d.MapFrom<bool>(src => src.Sunday))
             .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays.OrderBy(x => x.WeekNo)))
             .ForMember(x => x.TemplateName, d => d.MapFrom<string>(src => src.TemplateProgram.Name))
             .ForMember(x => x.LogDates, opt => opt.Ignore());

            CreateMap<WorkoutLogDTO, WorkoutLog>()
                .ForMember<int>(x => x.WorkoutLogId, d => d.MapFrom(src => src.WorkoutLogId))
                .ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<int?>(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId ?? 0))
                .ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
                .ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
                .ForMember<bool>(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember<bool>(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember<bool>(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember<bool>(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember<bool>(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember<bool>(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember<bool>(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ForMember(x => x.WorkoutDays, d => d.MapFrom(src => src.WorkoutDays.OrderBy(x => x.Date)))
                .ForMember(x => x.TemplateProgram, opt => opt.Ignore());

            //CreateMap<WorkoutLogInputScratchDTO, WorkoutLog>().ForMember<int>(x => x.NoOfWeeks, d => d.MapFrom(src => src.NoOfWeeks))
            //    .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
            //    .ForMember<string>(x => x.CustomName, d => d.MapFrom(src => src.CustomName))
            //    .ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
            //    .ForMember<DateTime>(x => x.EndDate, d => d.MapFrom(src => src.EndDate))
            //    .ForMember(x => x.WorkoutLogWeeks, d => d.MapFrom(src => src.WorkoutLogWeeks))
            //    .ForMember(x => x.TemplateWorkout, d => d.Ignore());

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
                .ForMember<DateTime>(x => x.StartDate, d => d.MapFrom(src => src.StartDate))
                .ForMember(x => x.CustomName, d => d.MapFrom(src => src.CustomName));

            //into entity
            CreateMap<WorkoutDayDTO, WorkoutDay>()
                .ForMember<int>(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember<int?>(x => x.WorkoutLogId, d => d.MapFrom(src => src.WorkoutLogId))
                .ForMember<string>(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<DateTime>(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember<bool>(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises));

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

            //into dto
            CreateMap<WorkoutExercise, WorkoutExerciseDTO>()
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom<int>(src => src.WorkoutExerciseId))
                .ForMember(x => x.WorkoutDayId, d => d.MapFrom<int?>(src => src.WorkoutDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.WorkoutExerciseTonnageId, d => d.MapFrom<int>(src => src.WorkoutExerciseTonnageId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseTonnage, d => d.MapFrom<decimal>(src => src.WorkoutExerciseTonnage.ExerciseTonnage))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.WorkoutSets.Count()))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets.OrderBy(x => x.WeightLifted)));

            //into entity
            CreateMap<WorkoutExerciseDTO, WorkoutExercise>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int?>(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<int>(x => x.WorkoutExerciseTonnageId, d => d.MapFrom(src => src.WorkoutExerciseTonnageId))
                .ForMember(x => x.WorkoutExerciseTonnage, d => d.MapFrom(src => src.WorkoutExerciseTonnage))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.Exercise, d => d.Ignore());

            //into DTO
            CreateMap<WorkoutSet, WorkoutSetDTO>()
                .ForMember(x => x.WorkoutSetId, d => d.MapFrom<int>(src => src.WorkoutSetId))
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom<int>(src => src.WorkoutExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.PersonalBest, d => d.MapFrom<bool?>(src => src.LiftingStatAudit != null ? true : false))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
                .ForMember(x => x.RepsCompleted, d => d.MapFrom<int>(src => src.RepsCompleted ?? src.NoOfReps)) //default to noOfReps if not been touched
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int?>(src => src.LiftingStatAuditId));

            //into entity
            CreateMap<WorkoutSetDTO, WorkoutSet>()
                .ForMember(x => x.WorkoutSetId, d => d.MapFrom(src => src.WorkoutSetId))
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.RepsCompleted, d => d.MapFrom(src => src.RepsCompleted))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int?>(src => src.LiftingStatAuditId));

            CreateMap<WorkoutDay, WorkoutDaySummaryDTO>()
                .ForMember(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.WorkoutExerciseCount, d => d.MapFrom(src => src.WorkoutExercises.Count()))
                .ForMember(x => x.WorkoutExerciseSummaries, d => d.MapFrom(src => src.WorkoutExercises))
                .ForMember(x => x.PersonalBestCount, d => d.MapFrom(src => src.WorkoutExercises.Where(x => x.WorkoutSets.Any(x => x.LiftingStatAuditId != null)).Count()))
                .ForMember(x => x.TemplateName, d => d.MapFrom(src => src.WorkoutLog.CustomName));


            CreateMap<WorkoutExercise, WorkoutExerciseSummaryDTO>()
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.WorkoutSets.Count));
        }
    }
}
