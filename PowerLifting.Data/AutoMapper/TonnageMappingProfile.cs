using AutoMapper;
using PowerLifting.Data.DTOs.Tonnage;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.AutoMapper
{
    public class TonnageMappingProfile : Profile
    {
        public TonnageMappingProfile()
        {
            CreateMap<TonnageWeekExercise, TonnageWeekExerciseDTO>()
                .ForMember(dest => dest.TonnageWeekExerciseId, opt => opt.MapFrom(src => src.TonnageWeekExerciseId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogWeekId, opt => opt.MapFrom(src => src.ProgramLogWeekId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.WeekTonnage, opt => opt.MapFrom(src => src.WeekTonnage))
                .ReverseMap();

            CreateMap<TonnageDayExercise, TonnageDayExerciseDTO>()
                .ForMember(dest => dest.TonnageDayExerciseId, opt => opt.MapFrom(src => src.TonnageDayExerciseId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogId, opt => opt.MapFrom(src => src.ProgramLogId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.DayTonnage, opt => opt.MapFrom(src => src.DayTonnage))
                .ReverseMap();

            CreateMap<TonnageLogExercise, TonnageLogExerciseDTO>()
                .ForMember(dest => dest.TonnageLogExerciseId, opt => opt.MapFrom(src => src.TonnageLogExerciseId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogId, opt => opt.MapFrom(src => src.ProgramLogId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.TotalTonnage, opt => opt.MapFrom(src => src.TotalTonnage))
                .ReverseMap();
        }
    }
}
