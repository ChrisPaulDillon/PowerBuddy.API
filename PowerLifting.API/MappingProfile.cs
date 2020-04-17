using AutoMapper;
using Powerlifting.Service.Exercises.DTO;
using Powerlifting.Service.Exercises.Model;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramLogs.DTO;
using Powerlifting.Services.ProgramLogRepSchemes.DTO;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using PowerLifting.ProgramLogExercises.Model;
using Powerlifting.Service.TemplateExercises.DTO;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;
using PowerLifting.Services.ProgramLogExercises.DTO;
using Powerlifting.Services.ProgramLogRepSchemess.DTO;
using PowerLifting.Services.TemplateRepSchemes.DTO;
using PowerLifting.Services.TemplateRepSchemes.Model;
using PowerLifting.Services.Users.DTO;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.Exercises.DTO;
using Powerlifting.Service.TemplateExercises.Model;
using Powerlifting.Service.TemplatePrograms.DTO;
using Powerlifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.TemplateWeek.Model;
using PowerLifting.Service.TemplateWeeks.DTO;
using PowerLifting.Service.TemplateDays.DTO;
using PowerLifting.Service.TemplateDays.Model;
using PowerLifting.Service.ProgramWeeks.DTO;
using PowerLifting.Service.ProgramLogWeeks.Model;
using PowerLifting.Service.ProgramLogDays.Model;
using PowerLifting.Service.ProgramLogDays.DTO;

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

            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<ProgramLogDTO, ProgramLog>();
            CreateMap<ProgramLog, ProgramLogDTO>();

            CreateMap<ProgramLogWeek, ProgramLogWeekDTO>();
            CreateMap<ProgramLogWeekDTO, ProgramLogWeek>();

            CreateMap<ProgramLogDay, ProgramLogDayDTO>();
            CreateMap<ProgramLogDayDTO, ProgramLogDay>();

            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>();
            CreateMap<ProgramLogExerciseDTO, ProgramLogExercise>();

            CreateMap<ProgramLogRepScheme, ProgramLogRepSchemeDTO>();
            CreateMap<ProgramLogRepSchemeDTO, ProgramLogRepScheme>();
            CreateMap<MarkupProgramLogRepSchemeDTO, ProgramLogRepScheme>();
            CreateMap<ProgramLogRepScheme, MarkupProgramLogRepSchemeDTO>();

            //Program Templates
            CreateMap<TemplateProgram, TemplateProgramDTO>();
            CreateMap<TemplateProgramDTO, TemplateProgram>();
            CreateMap<TemplateProgram, TopLevelTemplateProgramDTO>();

            CreateMap<TemplateWeek, TemplateWeekDTO>();
            CreateMap<TemplateWeekDTO, TemplateWeek>();

            CreateMap<TemplateDay, TemplateDayDTO>();
            CreateMap<TemplateDayDTO, TemplateDay>();

            CreateMap<TemplateExercise, TemplateExerciseDTO>();
            CreateMap<TemplateExerciseDTO, TemplateExercise>();

            CreateMap<TemplateRepScheme, TemplateRepSchemeDTO>();
            CreateMap<TemplateRepSchemeDTO, TemplateRepScheme>();


            
            
           
        }
    }
}
