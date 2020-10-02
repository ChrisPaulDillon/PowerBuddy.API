using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.DTOs.Tonnage;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Data.Entities.Tonnage;

namespace PowerLifting.Data.AutoMapper
{
    public class TonnageMappingProfile : Profile
    {
        public TonnageMappingProfile()
        {
            CreateMap<WeekTonnage, WeekTonnageDTO>()
                .ForMember(dest => dest.WeekTonnageId, opt => opt.MapFrom(src => src.WeekTonnageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogWeekId, opt => opt.MapFrom(src => src.ProgramLogWeekId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.TotalTonnage, opt => opt.MapFrom(src => src.TotalTonnage))
                .ReverseMap();

            CreateMap<LogTonnage, LogTonnageDTO>()
                .ForMember(dest => dest.LogTonnageId, opt => opt.MapFrom(src => src.LogTonnageId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ProgramLogId, opt => opt.MapFrom(src => src.ProgramLogId))
                .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.TotalTonnage, opt => opt.MapFrom(src => src.TotalTonnage))
                .ReverseMap();
        }
    }
}
