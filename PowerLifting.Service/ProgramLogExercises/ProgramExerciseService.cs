﻿using System;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Services.ProgramLogExercises
{
    public class ProgramLogExerciseService : IProgramLogExerciseService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;
        
        public ProgramLogExerciseService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
