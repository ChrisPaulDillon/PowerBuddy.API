using AutoMapper;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.AutoMapper
{
    public class ProgramLogMappingProfile : Profile
    {
        public ProgramLogMappingProfile()
        {
            CreateMap<ProgramLogDTO, ProgramLog>().ReverseMap();

            CreateMap<ProgramLogWeek, ProgramLogWeekDTO>().ReverseMap();

            CreateMap<ProgramLogDay, ProgramLogDayDTO>().ReverseMap();

            CreateMap<ProgramLogExercise, ProgramLogExerciseDTO>().ReverseMap();
            CreateMap<ProgramLogExercise, CProgramLogExerciseDTO>().ReverseMap();

            CreateMap<ProgramLogRepScheme, ProgramLogRepSchemeDTO>().ReverseMap();
            CreateMap<CProgramLogRepSchemeDTO, ProgramLogRepScheme>().ReverseMap();

            CreateMap<ProgramLogStatDTO, ProgramLog>()
                .ForMember(x => x.ProgramLogId, d => d.MapFrom(src => src.ProgramLogId))
                .ForMember(x => x.TemplateProgramId, d => d.MapFrom(src => src.TemplateProgramId))
                .ForMember(x => x.Monday, d => d.MapFrom(src => src.Monday))
                .ForMember(x => x.Tuesday, d => d.MapFrom(src => src.Tuesday))
                .ForMember(x => x.Wednesday, d => d.MapFrom(src => src.Wednesday))
                .ForMember(x => x.Thursday, d => d.MapFrom(src => src.Thursday))
                .ForMember(x => x.Friday, d => d.MapFrom(src => src.Friday))
                .ForMember(x => x.Saturday, d => d.MapFrom(src => src.Saturday))
                .ForMember(x => x.Sunday, d => d.MapFrom(src => src.Sunday))
                .ReverseMap();
        }
    }
}
