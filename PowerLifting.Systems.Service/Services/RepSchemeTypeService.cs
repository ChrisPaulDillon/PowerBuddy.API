﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.SystemServices.RepSchemeTypes.DTO;
using PowerLifting.Systems.Contracts.Services;

namespace PowerLifting.Systems.Service
{
    public class RepSchemeTypeService : IRepSchemeTypeService
    {
        private readonly IMapper _mapper;
        private readonly ISystemWrapper _repo;
        private readonly ConcurrentDictionary<int, RepSchemeTypeDTO> _store;

        public RepSchemeTypeService(ISystemWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _store = new ConcurrentDictionary<int, RepSchemeTypeDTO>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<RepSchemeTypeDTO>> GetAllRepSchemeTypes()
        {
            await RefreshRepSchemeTypeStore();
            return _store.Values;
        }

        private async Task RefreshRepSchemeTypeStore()
        {
            if (!_store.IsEmpty)
                return;

            var exercises = await _repo.RepSchemeType.GetAllRepSchemeTypes();
            var exerciseDTOs = _mapper.Map<IEnumerable<RepSchemeTypeDTO>>(exercises);

            foreach (var repSchemeTypeDTO in exerciseDTOs)
                _store.AddOrUpdate(repSchemeTypeDTO.RepSchemeTypeId, repSchemeTypeDTO, (key, olValue) => repSchemeTypeDTO);
        }
    }
}