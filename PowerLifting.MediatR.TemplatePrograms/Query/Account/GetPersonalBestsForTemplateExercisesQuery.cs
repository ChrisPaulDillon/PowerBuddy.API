using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Account
{ 
    public class GetPersonalBestsForTemplateExercisesQuery : IRequest<IEnumerable<TemplateWeightInputDTO>>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }
        public GetPersonalBestsForTemplateExercisesQuery(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }
}