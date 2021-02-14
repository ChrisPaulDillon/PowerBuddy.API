using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OneOf;
using PowerBuddy.App.Services.Templates;
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
        private readonly ITemplateService _templateService;

        public GetTemplateProgramByIdQueryHandler(ITemplateService templateService)
        {
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