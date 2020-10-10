﻿using AutoMapper;
using System;
using PowerLifting.Data;
using PowerLifting.Data.Entities;

namespace PowerLifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId)
        {
            var liftingStatAudit = new LiftingStatAudit()
            {
                LiftingStatId = liftingStatId,
                ExerciseId = exerciseId,
                RepRange = repRange,
                Weight = weight,
                UserId = userId,
                DateChanged = DateTime.UtcNow
            };

            _context.LiftingStatAudit.Add(liftingStatAudit);
        }
    }
}
