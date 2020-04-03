﻿using System;
using AutoMapper;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Services.TemplateExercises;

namespace PowerLifting.Services.TemplateExercises
{
    public class TemplateExerciseService : ITemplateExerciseService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public TemplateExerciseService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
