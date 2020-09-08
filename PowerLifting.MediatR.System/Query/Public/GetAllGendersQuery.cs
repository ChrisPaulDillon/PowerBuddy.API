﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.DTOs.Templates;

namespace PowerLifting.MediatR.System.Query.Public
{
    public class GetAllGendersQuery : IRequest<IEnumerable<GenderDTO>>
    {
        public GetAllGendersQuery()
        {
        }
    }
}