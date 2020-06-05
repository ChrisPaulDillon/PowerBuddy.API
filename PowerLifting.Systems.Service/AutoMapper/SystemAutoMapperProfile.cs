using AutoMapper;
using PowerLifting.Entity.System.ExerciseMuscleGroups.DTOs;
using PowerLifting.Entity.System.ExerciseMuscleGroups.Models;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Entity.System.ExerciseTypes.DTOs;
using PowerLifting.Entity.System.ExerciseTypes.Models;
using PowerLifting.Service.SystemServices.RepSchemeTypes.DTO;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;
using PowerLifting.Service.TemplatePrograms.DTO;

namespace PowerLifting.Service.Exercises.AutoMapper
{
    public class SystemAutoMapperProfile : Profile
    {
        public SystemAutoMapperProfile()
        {
            //Exercises
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<Exercise, TopLevelExerciseDTO>().ReverseMap();

            //Exercises types
            CreateMap<ExerciseType, ExerciseTypeDTO>().ReverseMap();

            //Exercise muscle groups
            CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupDTO>().ReverseMap();

            CreateMap<RepSchemeType, RepSchemeTypeDTO>().ReverseMap();
        }
    }
}
