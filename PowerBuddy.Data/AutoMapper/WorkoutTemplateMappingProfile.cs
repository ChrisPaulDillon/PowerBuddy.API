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
            CreateMap<WorkoutExercise, WorkoutTemplateExerciseDTO>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int>(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment));

            //into entity
            CreateMap<WorkoutTemplateExerciseDTO, WorkoutExercise>()
                .ForMember<int>(x => x.WorkoutExerciseId, d => d.MapFrom(src => src.WorkoutExerciseId))
                .ForMember<int>(x => (int) x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.WorkoutSets, d => d.MapFrom(src => src.WorkoutSets))
                .ForMember(x => x.Comment, d => d.MapFrom(src => src.Comment))
                .ForMember(x => x.Exercise, d => d.Ignore())
                .ForMember(x => x.WorkoutDayId, d => d.Ignore())
                .ForMember(x => x.WorkoutExerciseTonnage, d => d.Ignore());

        }
    }
}
