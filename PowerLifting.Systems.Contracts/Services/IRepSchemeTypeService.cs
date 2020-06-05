using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.RepSchemeTypes.DTO;

namespace PowerLifting.Systems.Contracts.Services
{
    public interface IRepSchemeTypeService
    {
        Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes();
    }
}
