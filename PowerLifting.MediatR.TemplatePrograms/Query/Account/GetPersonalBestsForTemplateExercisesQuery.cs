using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.LiftingStats;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Account
{ 
    public class GetPersonalBestsForTemplateExercisesQuery : IRequest<IEnumerable<LiftingStatDTO>>
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