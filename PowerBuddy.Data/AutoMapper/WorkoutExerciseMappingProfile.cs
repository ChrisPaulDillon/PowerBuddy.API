using System.Linq;
using AutoMapper;
using PowerBuddy.Data.Dtos.ProgramLogs.Workouts;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class WorkoutExerciseMappingProfile : Profile
    {
        public WorkoutExerciseMappingProfile()
        {
            //into Dto
            CreateMap<WorkoutExercise, WorkoutExerciseDto>()
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom<int>(src => src.WorkoutExerciseId))
                .ForMember(x => x.WorkoutDayId, d => d.MapFrom<int?>(src => src.WorkoutDayId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.WorkoutExerciseTonnageId, d => d.MapFrom<int>(src => src.WorkoutExerciseTonnageId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(x => x.ExerciseTonnage, d => d.MapFrom<decimal>(src => src.WorkoutExerciseTonnage.ExerciseTonnage))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.WorkoutSets.Count))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets.OrderBy(x => x.WeightLifted)));

            //into entity
            CreateMap<WorkoutExerciseDto, WorkoutExercise>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int?>(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember<string>(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember<int>(x => x.WorkoutExerciseTonnageId, d => d.MapFrom(src => src.WorkoutExerciseTonnageId))
                .ForMember(x => x.WorkoutExerciseTonnage, d => d.MapFrom(src => src.WorkoutExerciseTonnage))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.Exercise, d => d.Ignore())
                .ForMember(x => x.WorkoutTemplateId, d => d.Ignore());

            //into Dto
            CreateMap<WorkoutSet, WorkoutSetDto>()
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
            CreateMap<WorkoutSetDto, WorkoutSet>()
                .ForMember(x => x.WorkoutSetId, d => d.MapFrom(src => src.WorkoutSetId))
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.RepsCompleted, d => d.MapFrom(src => src.RepsCompleted))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
                .ForMember(x => x.LiftingStatAuditId, d => d.MapFrom<int?>(src => src.LiftingStatAuditId))
                .ForMember(x => x.LiftingStatAudit, d => d.Ignore());

            CreateMap<WorkoutDay, WorkoutDaySummaryDto>()
                .ForMember(x => x.WorkoutDayId, d => d.MapFrom(src => src.WorkoutDayId))
                .ForMember(x => x.Date, d => d.MapFrom(src => src.Date))
                .ForMember(x => x.Completed, d => d.MapFrom(src => src.Completed))
                .ForMember(x => x.WorkoutExerciseCount, d => d.MapFrom(src => src.WorkoutExercises.Count()))
                .ForMember(x => x.WorkoutExerciseSummaries, d => d.MapFrom(src => src.WorkoutExercises))
                .ForMember(x => x.PersonalBestCount, d => d.MapFrom(src => src.WorkoutExercises.Count(x => x.WorkoutSets.Any(x => x.LiftingStatAuditId != null))))
                .ForMember(x => x.TemplateName, d => d.MapFrom(src => src.WorkoutLog.CustomName))
                .ForMember(x => x.HasWorkoutData, d => d.Ignore());


            CreateMap<WorkoutExercise, WorkoutExerciseSummaryDto>()
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.WorkoutSets.Count));
        }
    }
}
