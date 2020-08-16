using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Public
{
    public class GetTecByTemplateProgramIdQuery : IRequest<IEnumerable<int>>
    {
        public int TemplateProgramId { get; }
        public GetTecByTemplateProgramIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }
}