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
using PowerLifting.Data.Exceptions.Account;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.TemplatePrograms.Command.Admin;
using PowerLifting.MediatR.TemplatePrograms.Query.Public;

namespace PowerLifting.MediatR.TemplatePrograms.CommandHandler.Admin
{
    public class CreateTemplateProgramCommandHandler : IRequestHandler<CreateTemplateProgramCommand, TemplateProgramDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateTemplateProgramCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateProgramDTO> Handle(CreateTemplateProgramCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.Rights >= 1, cancellationToken: cancellationToken);

            if (!isUserAdmin) throw new UnauthorisedUserException();

            var isTaken = await _context.Set<TemplateProgram>().AsNoTracking().AnyAsync(x => x.Name == request.TemplateProgramDTO.Name, cancellationToken: cancellationToken);
            if (isTaken) throw new TemplateProgramNameAlreadyExistsException();

            var template = _mapper.Map<TemplateProgram>(request.TemplateProgramDTO);
            _context.TemplateProgram.Add(template);

            await _context.SaveChangesAsync(cancellationToken);
            return request.TemplateProgramDTO;
        }
    }
}