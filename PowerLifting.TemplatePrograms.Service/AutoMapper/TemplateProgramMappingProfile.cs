using AutoMapper;
using PowerLifting.Service.TemplatePrograms.DTO;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.AutoMapper
{
    public class TemplateProgramMappingProfile : Profile
    {
        public TemplateProgramMappingProfile()
        {
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
