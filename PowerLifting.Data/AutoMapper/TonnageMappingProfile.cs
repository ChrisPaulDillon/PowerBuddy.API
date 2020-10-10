using AutoMapper;
using PowerLifting.Data.DTOs.Tonnage;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.AutoMapper
{
    public class TonnageMappingProfile : Profile
    {
        public TonnageMappingProfile()
        {
            CreateMap<TonnageWeek, TonnageWeekDTO>()
                .ForMember(dest => dest.TonnageWeekId, opt => opt.MapFrom(src => src.TonnageWeekId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogWeekId, opt => opt.MapFrom(src => src.ProgramLogWeekId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.WeekTonnage, opt => opt.MapFrom(src => src.WeekTonnage))
                .ReverseMap();

            CreateMap<TonnageDay, TonnageDayDTO>()
                .ForMember(dest => dest.TonnageDayId, opt => opt.MapFrom(src => src.TonnageDayId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogId, opt => opt.MapFrom(src => src.ProgramLogId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.DayTonnage, opt => opt.MapFrom(src => src.DayTonnage))
                .ReverseMap();

            CreateMap<TonnageLog, TonnageLogDTO>()
                .ForMember(dest => dest.TonnageLogId, opt => opt.MapFrom(src => src.TonnageLogId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogId, opt => opt.MapFrom(src => src.ProgramLogId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.TotalTonnage, opt => opt.MapFrom(src => src.TotalTonnage))
                .ReverseMap();
        }
    }
}
