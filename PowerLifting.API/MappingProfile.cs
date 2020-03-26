using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Service.ProgramExercises.DTO;
using Powerlifting.Service.ProgramExercises.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.IndividualSets.DTO;
using Powerlifting.Services.IndividualSets.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ProgramTemplates;
using Powerlifting.Services.ProgramTemplates.DTO;
using Powerlifting.Services.Users.DTO;
using Powerlifting.Services.Users.Model;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.ExerciseMarkups.Model;

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
