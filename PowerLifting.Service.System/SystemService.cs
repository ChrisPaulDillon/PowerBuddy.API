using AutoMapper;
using PowerLifting.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Service.System
{
    public class SystemService : ISystemService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public SystemService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<GenderDTO> GetAllGendersQueryable()
        {
            return _context.Gender.AsNoTracking().ProjectTo<GenderDTO>(_mapper.ConfigurationProvider);
        }

        public IQueryable<MemberStatusDTO> GetAllMemberStatusQueryable()
        {
            return _context.MemberStatus.AsNoTracking().ProjectTo<MemberStatusDTO>(_mapper.ConfigurationProvider);
        }
    }
}
