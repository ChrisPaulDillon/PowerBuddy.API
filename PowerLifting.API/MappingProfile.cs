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
using PowerLifting.Services.Users.DTO;

namespace PowerLifting.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Users
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<NewUserDTO, User>();

            //Program Templates
            CreateMap<ProgramTemplate, ProgramTemplateDTO>();
            CreateMap<ProgramTemplateDTO, ProgramTemplate>();
            CreateMap<ProgramTemplate, TopLevelProgramTemplateDTO>();

            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseDTO, Exercise>();
            CreateMap<TopLevelProgramTemplateDTO, Exercise>();

            CreateMap<LiftingStat, LiftingStatDTO>();

            CreateMap<ExerciseCategory, ExerciseCategoryDTO>();
            CreateMap<ProgramLog, ProgramLogDTO>();
            CreateMap<IndividualSet, IndividualSetDTO>();
            CreateMap<ExerciseMarkup, ExerciseMarkupDTO>();
            
            CreateMap<ProgramExercise, ProgramExerciseDTO>();

            
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<ExerciseCategoryDTO, ExerciseCategory>();
            CreateMap<ProgramLogDTO, ProgramLog>();
            CreateMap<IndividualSetDTO, IndividualSet>();
            CreateMap<ExerciseMarkupDTO, ExerciseMarkup>();
            
            CreateMap<ProgramExerciseDTO, ProgramExercise>();
        }
    }
}
