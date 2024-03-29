﻿using AutoMapper;
using PowerBuddy.Data.Dtos.Exercises;
using PowerBuddy.Data.Dtos.System;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.AutoMapper
{
    public class SystemAutoMapperProfile : Profile
    {
        public SystemAutoMapperProfile()
        {
            //Exercises
            CreateMap<Exercise, ExerciseDto>()
                .ForMember(x => x.ExerciseId, d => d.MapFrom<int>(src => src.ExerciseId))
                .ForMember(x => x.ExerciseTypeId, d => d.MapFrom<int?>(src => src.ExerciseTypeId))
                .ForMember(x => x.ExerciseName, d => d.MapFrom<string>(src => src.ExerciseName))
                .ForMember(x => x.ExerciseTypeName, d => d.MapFrom(src => src.ExerciseType.ExerciseTypeName))
                .ForMember(x => x.IsMainExercise, d => d.MapFrom<bool>(src => src.IsMainExercise))
                .ForMember(x => x.IsApproved, d => d.MapFrom<bool>(src => src.IsApproved))
                .ForMember(x => x.AdminApprover, d => d.MapFrom<string>(src => src.AdminApprover))
                .ForMember(x => x.ExerciseSports, d => d.MapFrom(src => src.ExerciseSports))
                .ForMember(x => x.ExerciseMuscleGroups, d => d.MapFrom(src => src.ExerciseMuscleGroups));

            CreateMap<ExerciseDto, Exercise>()
                .ForMember<int>(x => x.ExerciseId, d => d.MapFrom(src => src.ExerciseId))
                .ForMember<int?>(x => x.ExerciseTypeId, d => d.MapFrom(src => src.ExerciseTypeId))
                .ForMember<string>(x => x.ExerciseName, d => d.MapFrom(src => src.ExerciseName))
                .ForMember<bool>(x => x.IsMainExercise, d => d.MapFrom(src => src.IsMainExercise))
                .ForMember<bool>(x => x.IsApproved, d => d.MapFrom(src => src.IsApproved))
                .ForMember<string>(x => x.AdminApprover, d => d.MapFrom(src => src.AdminApprover))
                .ForMember(x => x.ExerciseSports, d => d.MapFrom(src => src.ExerciseSports))
                .ForMember(x => x.ExerciseMuscleGroups, d => d.MapFrom(src => src.ExerciseMuscleGroups))
                .ForMember(x => x.ExerciseType, d => d.Ignore())
                .ForMember(x => x.LiftingStatAudit, d => d.Ignore());

            CreateMap<Exercise, TopLevelExerciseDto>().ReverseMap();
            CreateMap<Exercise, CExerciseDto>().ReverseMap();

            //Exercises types
            CreateMap<ExerciseType, ExerciseTypeDto>().ReverseMap();

            //Exercise muscle groups
            CreateMap<ExerciseMuscleGroupAssoc, ExerciseMuscleGroupAssocDto>().ReverseMap();
            CreateMap<ExerciseMuscleGroup, ExerciseMuscleGroupDto>().ReverseMap();

            CreateMap<RepSchemeType, RepSchemeTypeDto>().ReverseMap();

            CreateMap<Quote, QuoteDto>().ReverseMap();

            CreateMap<ExerciseSport, ExerciseSportDto>().ReverseMap();

            CreateMap<Gender, GenderDto>();
            CreateMap<MemberStatus, MemberStatusDto>();
            CreateMap<LiftingLevel, LiftingLevelDto>();
        }
    }
}
