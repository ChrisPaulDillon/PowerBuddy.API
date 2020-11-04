using AutoMapper;
using PowerLifting.Data.DTOs.Exercises;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities;

namespace PowerLifting.Data.AutoMapper
{
    public class SystemAutoMapperProfile : Profile
    {
        public SystemAutoMapperProfile()
        {
            //Exercises
            CreateMap<Exercise, ExerciseDTO>()
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.ExerciseTypeId, d => d.MapFrom(src => src.ExerciseTypeId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.ExerciseName))
                .ForMember(x => x.ExerciseTypeName, d => d.MapFrom(src => src.ExerciseType.ExerciseTypeName))
                .ForMember(x => x.IsMainExercise, d => d.MapFrom(src => src.IsMainExercise))
                .ForMember(x => x.IsApproved, d => d.MapFrom(src => src.IsApproved))
                .ForMember(x => x.AdminApprover, d => d.MapFrom(src => src.AdminApprover))
                .ForMember(x => x.ExerciseSports, d => d.MapFrom(src => src.ExerciseSports))
                .ForMember(x => x.ExerciseMuscleGroups, d => d.MapFrom(src => src.ExerciseMuscleGroups));

            CreateMap<ExerciseDTO, Exercise>()
                .ForMember(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember(x => x.ExerciseTypeId, d => d.MapFrom(src => src.ExerciseTypeId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom(src => src.ExerciseName))
                .ForMember(x => x.IsMainExercise, d => d.MapFrom(src => src.IsMainExercise))
                .ForMember(x => x.IsApproved, d => d.MapFrom(src => src.IsApproved))
                .ForMember(x => x.AdminApprover, d => d.MapFrom(src => src.AdminApprover))
                .ForMember(x => x.ExerciseSports, d => d.MapFrom(src => src.ExerciseSports))
                .ForMember(x => x.ExerciseMuscleGroups, d => d.MapFrom(src => src.ExerciseMuscleGroups))
                .ForMember(x => x.ExerciseType, d => d.Ignore());

            CreateMap<Exercise, TopLevelExerciseDTO>().ReverseMap();
            CreateMap<Exercise, CExerciseDTO>().ReverseMap();

            //Exercises types
            CreateMap<ExerciseType, ExerciseTypeDTO>().ReverseMap();

            //Exercise muscle groups
            CreateMap<ExerciseMuscleGroupAssoc, ExerciseMuscleGroupAssocDTO>().ReverseMap();
            CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupDTO>().ReverseMap();

            CreateMap<RepSchemeType, RepSchemeTypeDTO>().ReverseMap();

            CreateMap<Quote, QuoteDTO>().ReverseMap();

            CreateMap<ExerciseSport, ExerciseSportDTO>().ReverseMap();

            CreateMap<Gender, GenderDTO>();
            CreateMap<MemberStatus, MemberStatusDTO>();
            CreateMap<LiftingLevel, LiftingLevelDTO>();
        }
    }
}
