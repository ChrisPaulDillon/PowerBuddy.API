﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface IRepSchemeTypeRepository
    {
        Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes();
    }
}
