using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.TemplatePrograms.Command.Admin
{ 
    public class CreateTemplateExerciseCollectionForTemplateCommand : IRequest<bool>
    {
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateTemplateExerciseCollectionForTemplateCommand(int templateProgramId, string userId)
        {
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }
}