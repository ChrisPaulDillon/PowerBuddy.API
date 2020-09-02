using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Command.Admin
{ 
    public class CreateAllTemplateExerciseCollectionForTemplateCommand : IRequest<bool>
    {
        public string UserId { get; }

        public CreateAllTemplateExerciseCollectionForTemplateCommand(string userId)
        {
            UserId = userId;
        }
    }
}