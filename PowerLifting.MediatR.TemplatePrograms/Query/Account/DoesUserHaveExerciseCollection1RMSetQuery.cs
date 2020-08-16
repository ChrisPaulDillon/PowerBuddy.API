using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.MediatR.TemplatePrograms.Query.Account
{ 
    public class DoesUserHaveExerciseCollection1RMSetQuery : IRequest<IEnumerable<int>>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }
        public DoesUserHaveExerciseCollection1RMSetQuery(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }
}