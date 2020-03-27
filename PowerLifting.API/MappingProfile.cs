using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Service.ProgramExercises.DTO;
using Powerlifting.Service.ProgramExercises.Model;
using Powerlifting.Services.ExerciseCategories.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ProgramLogSets.DTO;
using Powerlifting.Services.ProgramLogSets.Model;
using Powerlifting.Services.ProgramTemplates.DTO;
using Powerlifting.Services.ProgramTemplates.Model;
using Powerlifting.Services.Users.DTO;
using Powerlifting.Services.Users.Model;
using PowerLifting.Entities.DTOs;
using PowerLifting.Entities.DTOs.Lookups;
using PowerLifting.ExerciseMarkups.Model;
using PowerLifting.Services.ProgramRepSchemes.DTO;
using PowerLifting.Services.ProgramRepSchemes.Model;
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

            CreateMap<ProgramLogSet, ProgramLogSetDTO>();
            CreateMap<ProgramLogSetDTO, ProgramLogSet>();
            CreateMap<MarkupProgramLogSetDTO, ProgramLogSet>();
            CreateMap<ProgramLogSet, MarkupProgramLogSetDTO>();

            CreateMap<ProgramRepScheme, ProgramRepSchemeDTO>();
            CreateMap<ProgramRepSchemeDTO, ProgramRepScheme>();

            CreateMap<LiftingStat, LiftingStatDTO>();

            CreateMap<ExerciseCategory, ExerciseCategoryDTO>();
            CreateMap<ProgramLog, ProgramLogDTO>();

      
            CreateMap<ExerciseMarkup, ExerciseMarkupDTO>();
            
            CreateMap<ProgramExercise, ProgramExerciseDTO>();

            
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<ExerciseCategoryDTO, ExerciseCategory>();
            CreateMap<ProgramLogDTO, ProgramLog>();
            
            CreateMap<ExerciseMarkupDTO, ExerciseMarkup>();
            
            CreateMap<ProgramExerciseDTO, ProgramExercise>();
        }
    }
}
