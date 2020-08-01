﻿using PowerLifting.Persistence;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Repository
{
    public class UserSettingRepository : IUserSettingRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UserSettingRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserSettingDTO> GetUserSettingsById(string userId)
        {
            return

        }
    }
}
