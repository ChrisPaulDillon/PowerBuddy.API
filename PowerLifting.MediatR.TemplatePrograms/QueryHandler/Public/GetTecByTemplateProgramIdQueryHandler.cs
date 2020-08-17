﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;

namespace PowerLifting.MediatR.TemplatePrograms.QueryHandler.Public
{
    public class GetTecByTemplateProgramIdQueryHandler : IRequestHandler<GetTecByTemplateProgramIdQuery, IEnumerable<int>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetTecByTemplateProgramIdQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> Handle(GetTecByTemplateProgramIdQuery request, CancellationToken cancellationToken)
        {
            return _context.TemplateExerciseCollection.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();
        }
    }
}