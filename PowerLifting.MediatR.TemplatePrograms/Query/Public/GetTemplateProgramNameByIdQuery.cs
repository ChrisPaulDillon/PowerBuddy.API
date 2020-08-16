using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Public
{
    public class GetTemplateProgramNameByIdQuery : IRequest<string>
    {
        public int TemplateProgramId { get; }
        public GetTemplateProgramNameByIdQuery(int templateProgramId)
        {
            TemplateProgramId = templateProgramId;
        }
    }
}