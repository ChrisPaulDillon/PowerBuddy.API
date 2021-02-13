using System.Linq;
using AutoMapper;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class TemplateProgramMappingProfile : Profile
    {
        public TemplateProgramMappingProfile()
        {
            CreateMap<TemplateProgram, TemplateProgramDto>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<string>(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom<string>(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom<string>(src => src.Difficulty))
                .ForMember(dest => dest.NoOfDaysPerWeek, opt => opt.MapFrom<int>(src => src.NoOfDaysPerWeek))
                .ForMember(dest => dest.NoOfWeeks, opt => opt.MapFrom<int>(src => src.TemplateDays.Max(x => x.WeekNo)))
                .ForMember(dest => dest.TemplateType, opt => opt.MapFrom<string>(src => src.TemplateType))
                .ForMember(dest => dest.WeightProgressionType, opt => opt.MapFrom<string>(src => src.WeightProgressionType))
                .ForMember(dest => dest.ActiveUsersCount, opt => opt.MapFrom(src => src.ActiveUsersCount));

            CreateMap<TemplateProgram, TemplateProgramExtendedDto>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<string>(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom<string>(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom<string>(src => src.Difficulty))
                .ForMember(dest => dest.NoOfDaysPerWeek, opt => opt.MapFrom<int>(src => src.NoOfDaysPerWeek))
                .ForMember(dest => dest.NoOfWeeks, opt => opt.MapFrom<int>(src => src.TemplateDays.Max(x => x.WeekNo)))
                .ForMember(dest => dest.TemplateType, opt => opt.MapFrom<string>(src => src.TemplateType))
                .ForMember(dest => dest.WeightProgressionType, opt => opt.MapFrom<string>(src => src.WeightProgressionType))
                .ForMember(dest => dest.ActiveUsersCount, opt => opt.MapFrom(src => src.ActiveUsersCount))
                .ForMember(dest => dest.TemplateWeeks, opt => opt.Ignore())
                .ForMember(dest => dest.TemplateExerciseCollection, opt => opt.MapFrom(src => src.TemplateExerciseCollection));

            CreateMap<TemplateExerciseCollection, TemplateExerciseCollectionDto>()
                .ForMember(dest => dest.TemplateExerciseCollectionId, opt => opt.MapFrom<int>(src => src.TemplateExerciseCollectionId))
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom<int>(src => src.ExerciseId))
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom<string>(src => src.Exercise.ExerciseName));

            CreateMap<TemplateExerciseCollectionDto, TemplateExerciseCollection>()
                .ForMember<int>(dest => dest.TemplateExerciseCollectionId, opt => opt.MapFrom(src => src.TemplateExerciseCollectionId))
                .ForMember<int>(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId))
                .ForMember<int>(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.Exercise, opt => opt.Ignore());

            CreateMap<TemplateDay, TemplateDayDto>()
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom<int>(src => src.TemplateDayId))
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom<int>(src => src.TemplateProgramId))
                .ForMember(dest => dest.WeekNo, opt => opt.MapFrom<int>(src => src.WeekNo))
                .ForMember(dest => dest.DayNo, opt => opt.MapFrom<int>(src => src.DayNo))
                .ForMember(dest => dest.TemplateExercises, opt => opt.MapFrom(src => src.TemplateExercises))
                .ReverseMap();

            CreateMap<TemplateExercise, TemplateExerciseDto>()
                .ForMember(dest => dest.TemplateExerciseId, opt => opt.MapFrom<int>(src => src.TemplateExerciseId))
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom<int>(src => src.TemplateDayId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom<int>(src => src.ExerciseId))
                .ForMember(dest => dest.NoOfSets, opt => opt.MapFrom<int>(src => src.TemplateRepSchemes.Count()))
                .ForMember(dest => dest.RepSchemeFormat, opt => opt.MapFrom(mapExpression: src =>
                    string.Join(", ", src.TemplateRepSchemes.OrderBy(x => x.Percentage).GroupBy(x => x.NoOfReps).Select(x => new string(x.Count().ToString() + "x" + x.Key.ToString())).ToList())
                ))
                .ForMember(dest => dest.RepSchemeType, opt => opt.MapFrom<string>(src => src.TemplateRepSchemes.GroupBy(o => o.Percentage).Count() == 1 ? "Fixed" : "Ramped"))
                .ForMember(dest => dest.HasBackOffSets, opt => opt.MapFrom<bool>(src => src.HasBackOffSets))
                .ForMember(dest => dest.BackOffSetFormat, opt => opt.MapFrom<string>(src => src.BackOffSetFormat))
                .ForMember(dest => dest.ExerciseName, opt => opt.MapFrom<string>(src => src.Exercise.ExerciseName))
                .ForMember(dest => dest.TemplateRepSchemes, opt => opt.MapFrom(src => src.TemplateRepSchemes.OrderBy(x => x.SetNo)));

            CreateMap<TemplateRepScheme, TemplateRepSchemeDto>()
                .ForMember(dest => dest.TemplateRepSchemeId, opt => opt.MapFrom(src => src.TemplateRepSchemeId))
                .ForMember(dest => dest.TemplateExerciseId, opt => opt.MapFrom(src => src.TemplateExerciseId))
                .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.Percentage))
                .ForMember(dest => dest.SetNo, opt => opt.MapFrom(src => src.SetNo))
                .ForMember(dest => dest.NoOfReps, opt => opt.MapFrom(src => src.NoOfReps))
                .ForMember(dest => dest.IsBackOffSet, opt => opt.MapFrom(src => src.IsBackOffSet))
                .ForMember(dest => dest.AMRAP, opt => opt.MapFrom(src => src.AMRAP))
                .ReverseMap();

            CreateMap<TemplateProgramAudit, TemplateProgramAuditDto>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.TemplateName, opt => opt.MapFrom(src => src.TemplateProgram.Name))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));

            CreateMap<TemplateProgram, TemplateKeyValuePairDto>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId))
                .ForMember(dest => dest.TemplateName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
