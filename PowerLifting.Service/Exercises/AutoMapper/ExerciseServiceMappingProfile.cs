using AutoMapper;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.Exercises.Model;
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
