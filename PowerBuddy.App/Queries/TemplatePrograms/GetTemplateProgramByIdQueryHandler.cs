using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Services.Templates;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Models.TemplatePrograms;
using PowerBuddy.Util;

namespace PowerBuddy.App.Queries.TemplatePrograms
{
    public class GetTemplateProgramByIdQuery : IRequest<OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>>
    {
        public int TemplateProgramId { get; }

        public GetTemplateProgramByIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }

    public class GetTemplateProgramByIdQueryValidator : AbstractValidator<GetTemplateProgramByIdQuery>
    {
        public GetTemplateProgramByIdQueryValidator()
        {
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    internal class GetTemplateProgramByIdQueryHandler : IRequestHandler<GetTemplateProgramByIdQuery, OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly ITemplateService _templateService;

        public GetTemplateProgramByIdQueryHandler(PowerLiftingContext context, ITemplateService templateService)
        {
            _context = context;
            _templateService = templateService;
        }

        public async Task<OneOf<TemplateProgramExtendedDto, TemplateProgramNotFound>> Handle(GetTemplateProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var templateProgram = await _templateService.GetTemplateProgramById(request.TemplateProgramId);

            if (templateProgram == null)
            {
                return new TemplateProgramNotFound();
            }

            return templateProgram;
        }
    }
}