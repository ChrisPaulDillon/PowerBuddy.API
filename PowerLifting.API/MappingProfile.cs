using AutoMapper;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.Entities.DTOs.Programs;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;

namespace PowerLifting.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseCategory, ExerciseCategoryDTO>();
            CreateMap<ProgramLog, ProgramLogDTO>();
            CreateMap<IndividualSet, IndividualSetDTO>();
            CreateMap<ExerciseMarkup, ExerciseMarkupDTO>();
            CreateMap<ProgramTemplate, ProgramTemplateDTO>();
            CreateMap<ProgramExercise, ProgramExerciseDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<LiftingStatDTO, LiftingStat>();
            CreateMap<ExerciseDTO, Exercise>();
            CreateMap<ExerciseCategoryDTO, ExerciseCategory>();
            CreateMap<ProgramLogDTO, ProgramLog>();
            CreateMap<IndividualSetDTO, IndividualSet>();
            CreateMap<ExerciseMarkupDTO, ExerciseMarkup>();
            CreateMap<ProgramTemplateDTO, ProgramTemplate>();
            CreateMap<ProgramExerciseDTO, ProgramExercise>();
        }
    }
}
