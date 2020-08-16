using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.Persistence;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateProgramService : ITemplateProgramService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateProgramService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}