using AutoMapper;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.AutoMapper
{
    public class SystemAutoMapperProfile : Profile
    {
        public SystemAutoMapperProfile()
        {
            //Exercises
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
            CreateMap<Exercise, TopLevelExerciseDTO>().ReverseMap();
            CreateMap<Exercise, CExerciseDTO>().ReverseMap();

            //Exercises types
            CreateMap<ExerciseType, ExerciseTypeDTO>().ReverseMap();

            //Exercise muscle groups
            CreateMap<ExerciseMuscleGroupAssoc, ExerciseMuscleGroupAssocDTO>().ReverseMap();
            CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupDTO>().ReverseMap();

            CreateMap<RepSchemeType, RepSchemeTypeDTO>().ReverseMap();

            CreateMap<Quote, QuoteDTO>().ReverseMap();

            CreateMap<ExerciseSport, ExerciseSportDTO>().ReverseMap();

        }
    }
}
