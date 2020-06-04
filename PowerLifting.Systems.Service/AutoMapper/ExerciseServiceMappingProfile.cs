using AutoMapper;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.Service.Exercises.AutoMapper
{
    public class ExerciseServiceMappingProfile : Profile
    {
        public ExerciseServiceMappingProfile()
        {
            //Exercises
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseDTO, Exercise>();
            CreateMap<TopLevelTemplateProgramDTO, Exercise>();
            CreateMap<Exercise, TopLevelExerciseDTO>();

            //Exercises types
            CreateMap<ExerciseType, ExerciseTypeDTO>();
            CreateMap<ExerciseType, ExerciseTypeDTO>();

            //Exercise muscle groups
            CreateMap<ExerciseMuscleGroupDTO, ExerciseMuscleGroup>();
            CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupDTO>();
        }
    }
}
