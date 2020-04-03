﻿using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ProgramLogRepSchemes.DTO;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using Powerlifting.Services.TemplatePrograms.DTO;
using Powerlifting.Services.TemplatePrograms.Model;
using PowerLifting.ProgramLogExercises.Model;
using Powerlifting.Service.TemplateExercises.DTO;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;
using PowerLifting.Services.ProgramLogExercises.DTO;
using Powerlifting.Services.ProgramLogRepSchemess.DTO;
using PowerLifting.Services.TemplateRepSchemes.DTO;
using PowerLifting.Services.TemplateRepSchemes.Model;
using Powerlifting.Services.TemplateExercises.Model;
using PowerLifting.Services.Users.DTO;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.Exercises.DTO;

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
            CreateMap<TemplateProgram, TemplateProgramDTO>();
            CreateMap<TemplateProgramDTO, TemplateProgram>();
            CreateMap<TemplateProgram, TopLevelTemplateProgramDTO>();

            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseDTO, Exercise>();
            CreateMap<TopLevelTemplateProgramDTO, Exercise>();

            CreateMap<ProgramLogRepScheme, ProgramLogRepSchemeDTO>();
            CreateMap<ProgramLogRepSchemeDTO, ProgramLogRepScheme>();
            CreateMap<MarkupProgramLogRepSchemeDTO, ProgramLogRepScheme>();
            CreateMap<ProgramLogRepScheme, MarkupProgramLogRepSchemeDTO>();

            CreateMap<TemplateRepScheme, TemplateRepSchemeDTO>();
            CreateMap<TemplateRepSchemeDTO, TemplateRepScheme>();

            CreateMap<LiftingStat, LiftingStatDTO>();

            CreateMap<ExerciseType, ExerciseTypeDTO>();
            CreateMap<ExerciseType, ExerciseTypeDTO>();

            CreateMap<ProgramLog, ProgramLogDTO>();

      
            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>();
            
            CreateMap<TemplateExercise, TemplateExerciseDTO>();

            
            CreateMap<LiftingStatDTO, LiftingStat>();

            
            CreateMap<ProgramLogDTO, ProgramLog>();
            
            CreateMap<ProgramLogExerciseDTO, ProgramLogExercise>();
            
            CreateMap<TemplateExerciseDTO, TemplateExercise>();
        }
    }
}
