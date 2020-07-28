using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.Systems.Service
{
    public interface IRepSchemeTypeService
    {
        Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes();
    }
}
