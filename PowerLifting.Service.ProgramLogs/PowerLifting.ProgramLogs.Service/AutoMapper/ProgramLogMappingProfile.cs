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
        }
    }
}
