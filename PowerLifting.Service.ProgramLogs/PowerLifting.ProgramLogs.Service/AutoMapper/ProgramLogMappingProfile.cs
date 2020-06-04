using AutoMapper;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.AutoMapper
{
    public class ProgramLogMappingProfile : Profile
    {
        public ProgramLogMappingProfile()
        {
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
        }
    }
}
