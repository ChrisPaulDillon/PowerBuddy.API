using AutoMapper;
using PowerLifting.Service.Users.DTO;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.Exercises.Model;
using PowerLifting.Service.Exercises.DTO;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStatsAudit.DTO;
using PowerLifting.Service.LiftingStatsAudit.Model;
using PowerLifting.Service.ProgramLogs.DTO;
using PowerLifting.Service.ProgramLogs.Model;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Model;
using PowerLifting.Service.UserSettings.DTO;
using PowerLifting.Service.UserSettings.Model;

namespace PowerLifting.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
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

            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

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

            //Users
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<NewUserDTO, User>();

            //UserSettings
            CreateMap<UserSetting, UserSettingDTO>();
            CreateMap<UserSettingDTO, UserSetting>();

        }
    }
}
