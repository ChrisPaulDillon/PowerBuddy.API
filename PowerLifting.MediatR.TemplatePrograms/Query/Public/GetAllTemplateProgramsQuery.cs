using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Public
{
    public class GetAllTemplateProgramsQuery : IRequest<IEnumerable<TemplateProgramDTO>>
    {

        public GetAllTemplateProgramsQuery()
        {
        }
    }
}