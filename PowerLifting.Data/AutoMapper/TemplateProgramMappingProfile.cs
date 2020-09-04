using AutoMapper;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Data.AutoMapper
{
    public class TemplateProgramMappingProfile : Profile
    {
        public TemplateProgramMappingProfile()
        {
            CreateMap<TemplateProgram, TemplateProgramDTO>()
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.NoOfDaysPerWeek, opt => opt.MapFrom(src => src.NoOfDaysPerWeek))
                .ForMember(dest => dest.TemplateType, opt => opt.MapFrom(src => src.TemplateType))
                .ForMember(dest => dest.WeightProgressionType, opt => opt.MapFrom(src => src.WeightProgressionType))
                .ReverseMap();

            CreateMap<TemplateExerciseCollection, TemplateExerciseCollectionDTO>()
                .ForMember(dest => dest.TemplateExerciseCollectionId, opt => opt.MapFrom(src => src.TemplateExerciseCollectionId))
                .ForMember(dest => dest.TemplateProgramId, opt => opt.MapFrom(src => src.TemplateProgramId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ReverseMap();

            CreateMap<TemplateWeek, TemplateWeekDTO>()
                .ForMember(dest => dest.TemplateWeekId, opt => opt.MapFrom(src => src.TemplateWeekId))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.TemplateId))
                .ForMember(dest => dest.WeekNo, opt => opt.MapFrom(src => src.WeekNo))
                .ReverseMap();

            CreateMap<TemplateDay, TemplateDayDTO>()
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom(src => src.TemplateDayId))
                .ForMember(dest => dest.TemplateWeekId, opt => opt.MapFrom(src => src.TemplateWeekId))
                .ForMember(dest => dest.DayNo, opt => opt.MapFrom(src => src.DayNo))
                .ReverseMap();
   
            CreateMap<TemplateExercise, TemplateExerciseDTO>()
                .ForMember(dest => dest.TemplateExerciseId, opt => opt.MapFrom(src => src.TemplateExerciseId))
                .ForMember(dest => dest.TemplateDayId, opt => opt.MapFrom(src => src.TemplateDayId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.NoOfSets, opt => opt.MapFrom(src => src.NoOfSets))
                .ForMember(dest => dest.RepSchemeFormat, opt => opt.MapFrom(src => src.RepSchemeFormat))
                .ForMember(dest => dest.RepSchemeType, opt => opt.MapFrom(src => src.RepSchemeType))
                .ForMember(dest => dest.HasBackOffSets, opt => opt.MapFrom(src => src.HasBackOffSets))
                .ForMember(dest => dest.BackOffSetFormat, opt => opt.MapFrom(src => src.BackOffSetFormat))
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
        }
    }
}
