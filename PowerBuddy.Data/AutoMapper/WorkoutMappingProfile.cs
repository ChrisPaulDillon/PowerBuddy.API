using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //into dto
            CreateMap<ProgramLogExercise, WorkoutExerciseDTO>()
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom(src => src.ProgramLogExerciseId))
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.Exercise.ExerciseName))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.NoOfSets))
                .ForMember(x => x.ProgramLogRepSchemes, d => d.MapFrom(src => src.ProgramLogRepSchemes));

            //into entity
            CreateMap<WorkoutExerciseDTO, ProgramLogExercise>()
                .ForMember(x => x.ProgramLogExerciseId, d => d.MapFrom(src => src.ProgramLogExerciseId))
                .ForMember(x => x.WorkoutTemplateId, d => d.MapFrom(src => src.WorkoutTemplateId))
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.NoOfSets, d => d.MapFrom(src => src.NoOfSets))
                .ForMember(x => x.ProgramLogRepSchemes, d => d.MapFrom(src => src.ProgramLogRepSchemes))
                .ForMember(x => x.Exercise, d => d.Ignore())
                .ForMember(x => x.ProgramLogExerciseTonnage, d => d.Ignore());
        }
    }
}
