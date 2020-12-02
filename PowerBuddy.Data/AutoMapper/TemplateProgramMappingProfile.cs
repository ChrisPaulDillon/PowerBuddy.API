using System.Linq;
using AutoMapper;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class TemplateProgramMappingProfile : Profile
    {
        public TemplateProgramMappingProfile()
        {
            CreateMap<TemplateProgram, TemplateProgramDTO>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<string>(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom<string>(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom<string>(src => src.Difficulty))
                .ForMember(dest => dest.NoOfDaysPerWeek, opt => opt.MapFrom<int>(src => src.NoOfDaysPerWeek))
                .ForMember(dest => dest.TemplateType, opt => opt.MapFrom<string>(src => src.TemplateType))
                .ForMember(dest => dest.WeightProgressionType, opt => opt.MapFrom<string>(src => src.WeightProgressionType))
                .ForMember(dest => dest.ActiveUsersCount, opt => opt.MapFrom(src => src.ActiveUsersCount));

            CreateMap<TemplateProgram, TemplateProgramExtendedDTO>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<string>(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom<string>(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom<string>(src => src.Difficulty))
                .ForMember(dest => dest.NoOfDaysPerWeek, opt => opt.MapFrom<int>(src => src.NoOfDaysPerWeek))
                .ForMember(dest => dest.TemplateType, opt => opt.MapFrom<string>(src => src.TemplateType))
                .ForMember(dest => dest.WeightProgressionType, opt => opt.MapFrom<string>(src => src.WeightProgressionType))
                .ForMember(dest => dest.TemplateWeeks, opt => opt.MapFrom(src => src.TemplateWeeks.OrderBy<TemplateWeek, int>(x => x.WeekNo)))
                .ForMember(dest => dest.TemplateExerciseCollection, opt => opt.MapFrom(src => src.TemplateExerciseCollection));

            CreateMap<TemplateExerciseCollection, TemplateExerciseCollectionDTO>()
                .ForMember(dest => dest.TemplateExerciseCollectionId, opt => opt.MapFrom<int>(src => src.TemplateExerciseCollectionId))
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom<int>(src => src.ExerciseId))
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom<string>(src => src.Exercise.ExerciseName));

            CreateMap<TemplateExerciseCollectionDTO, TemplateExerciseCollection>().ForMember<int>(dest => dest.TemplateExerciseCollectionId, opt => opt.MapFrom(src => src.TemplateExerciseCollectionId)).ForMember<int>(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId)).ForMember<int>(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
               .ForMember(dest => dest.Exercise, opt => opt.Ignore());

            CreateMap<TemplateWeek, TemplateWeekDTO>()
                .ForMember(dest => dest.TemplateWeekId, opt => opt.MapFrom<int>(src => src.TemplateWeekId))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom<int>(src => src.TemplateId))
                .ForMember(dest => dest.WeekNo, opt => opt.MapFrom<int>(src => src.WeekNo))
                .ReverseMap();

            CreateMap<TemplateDay, TemplateDayDTO>()
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom<int>(src => src.TemplateDayId))
                .ForMember(dest => dest.TemplateWeekId, opt => opt.MapFrom<int>(src => src.TemplateWeekId))
                .ForMember(dest => dest.DayNo, opt => opt.MapFrom<int>(src => src.DayNo))
                .ReverseMap();

            CreateMap<TemplateExercise, TemplateExerciseDTO>()
                .ForMember(dest => dest.TemplateExerciseId, opt => opt.MapFrom<int>(src => src.TemplateExerciseId))
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom<int>(src => src.TemplateDayId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom<int>(src => src.ExerciseId))
                .ForMember(dest => dest.NoOfSets, opt => opt.MapFrom<int>(src => src.NoOfSets))
                .ForMember(dest => dest.RepSchemeFormat, opt => opt.MapFrom<string>(src => src.RepSchemeFormat))
                .ForMember(dest => dest.RepSchemeType, opt => opt.MapFrom<string>(src => src.RepSchemeType))
                .ForMember(dest => dest.HasBackOffSets, opt => opt.MapFrom<bool>(src => src.HasBackOffSets))
                .ForMember(dest => dest.BackOffSetFormat, opt => opt.MapFrom<string>(src => src.BackOffSetFormat))
                .ReverseMap();

            CreateMap<TemplateRepScheme, TemplateRepSchemeDTO>()
                .ForMember(dest => dest.TemplateRepSchemeId, opt => opt.MapFrom(src => src.TemplateExerciseId))
                .ForMember(dest => dest.TemplateExerciseId, opt => opt.MapFrom(src => src.TemplateExerciseId))
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Percentage))
                .ForMember(dest => dest.SetNo, opt => opt.MapFrom(src => src.SetNo))
                .ForMember(dest => dest.NoOfReps, opt => opt.MapFrom(src => src.NoOfReps))
                .ForMember(dest => dest.WeightLifted, opt => opt.MapFrom(src => src.WeightLifted))
                .ForMember(dest => dest.IsBackOffSet, opt => opt.MapFrom(src => src.IsBackOffSet))
                .ForMember(dest => dest.AMRAP, opt => opt.MapFrom(src => src.AMRAP))
                .ReverseMap();

            CreateMap<TemplateProgramAudit, TemplateProgramAuditDTO>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramAuditId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.TemplateName, opt => opt.MapFrom(src => src.TemplateProgram.Name))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));
        }
    }
}
