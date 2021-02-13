using AutoMapper;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.DTOs.WorkoutTemplates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class WorkoutTemplateMappingProfile : Profile
    {
        public WorkoutTemplateMappingProfile()
        {
            //into Dto
            CreateMap<WorkoutTemplate, WorkoutTemplateDto>()
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.WorkoutName, d => d.MapFrom(src => src.WorkoutName))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.DateCreated, d => d.MapFrom(src => src.DateCreated))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises));

            //into entity
            CreateMap<WorkoutTemplateDto, WorkoutTemplate>()
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.WorkoutName, d => d.MapFrom(src => src.WorkoutName))
                .ForMember(x => x.UserId, d => d.MapFrom(src => src.UserId))
                .ForMember(x => x.DateCreated, d => d.MapFrom(src => src.DateCreated))
                .ForMember(x => x.WorkoutExercises, d => d.MapFrom(src => src.WorkoutExercises));

            //into Dto
            CreateMap<WorkoutExercise, WorkoutTemplateExerciseDto>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int>(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.WorkoutSets.Count))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment));

            //into entity
            CreateMap<WorkoutTemplateExerciseDto, WorkoutExercise>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int>(x => (int) x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.Exercise, d => d.Ignore())
                .ForMember(x => x.WorkoutDayId, d => d.Ignore())
                .ForMember(x => x.WorkoutExerciseTonnageId, d => d.Ignore())
                .ForMember(x => x.WorkoutExerciseTonnage, d => d.Ignore());

            //into Dto
            CreateMap<WorkoutSet, WorkoutTemplateSetDto>()
                .ForMember(x => x.WorkoutSetId, d => d.MapFrom<int>(src => src.WorkoutSetId))
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom<int>(src => src.WorkoutExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP));

            //into entity
            CreateMap<WorkoutTemplateSetDto, WorkoutSet>()
                .ForMember(x => x.WorkoutSetId, d => d.MapFrom(src => src.WorkoutSetId))
                .ForMember(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember(x => x.Comment, d => d.MapFrom<string>(src => src.Comment))
                .ForMember(x => x.NoOfReps, d => d.MapFrom<int>(src => src.NoOfReps))
                .ForMember(x => x.WeightLifted, d => d.MapFrom<decimal>(src => src.WeightLifted))
                .ForMember(x => x.AMRAP, d => d.MapFrom<bool>(src => src.AMRAP))
                .ForMember(x => x.RepsCompleted, d => d.Ignore())
                .ForMember(x => x.LiftingStatAuditId, d => d.Ignore())
                .ForMember(x => x.LiftingStatAudit, d => d.Ignore());


        }
    }
}
