using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.SystemServices.RepSchemeTypes.DTO;
using PowerLifting.Service.SystemServices.RepSchemeTypes.Model;

namespace PowerLifting.Systems.Contracts.Repositories
{
    public interface IRepSchemeTypeRepository
    {
        Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes();
    }
}
