﻿using AutoMapper;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.Data.AutoMapper
{
    public class LiftingStatServiceMappingProfile : Profile
    {
        public LiftingStatServiceMappingProfile()
        {
            CreateMap<LiftingStat, LiftingStatDTO>();
            CreateMap<LiftingStatDTO, LiftingStat>();

            CreateMap<LiftingStatAudit, LiftingStatAuditDTO>();
            CreateMap<LiftingStatAuditDTO, LiftingStatAudit>();

        }
    }
}
