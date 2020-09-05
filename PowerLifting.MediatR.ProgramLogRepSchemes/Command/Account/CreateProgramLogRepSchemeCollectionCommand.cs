using MediatR;
using PowerLifting.Data.DTOs.ProgramLogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.MediatR.ProgramLogRepSchemes.Command.Account
{
    public class CreateProgramLogRepSchemeCollectionCommand : IRequest<IEnumerable<ProgramLogRepSchemeDTO>>
    {
        public IList<ProgramLogRepSchemeDTO> RepSchemeCollectionDTO { get; }
        public string UserId { get; }

        public CreateProgramLogRepSchemeCollectionCommand(IList<ProgramLogRepSchemeDTO> repSchemeDTOCollection, string userId)
        {
            RepSchemeCollectionDTO = repSchemeDTOCollection;
            UserId = userId;
        }
    }
}