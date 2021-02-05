using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Services.System;

namespace PowerBuddy.Repositories.System
{
    public class CachedSystemRepository : ISystemRepository
    {
        private readonly ISystemRepository _systemRepo;

        private static readonly ConcurrentDictionary<int, GenderDTO> _cachedGenders = new ConcurrentDictionary<int, GenderDTO>();
        private static readonly ConcurrentDictionary<int, MemberStatusDTO> _cachedMemberStatus = new ConcurrentDictionary<int, MemberStatusDTO>();
        private static readonly ConcurrentDictionary<int, LiftingLevelDTO> _cachedLiftingLevels = new ConcurrentDictionary<int, LiftingLevelDTO>();

        public CachedSystemRepository(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task<IEnumerable<GenderDTO>> GetAllGenders()
        {
            if (!_cachedGenders.IsEmpty)
            {
                return _cachedGenders.Values;
            }

            var genders = await _systemRepo.GetAllGenders();
            foreach (var gender in genders)
            {
                _cachedGenders.TryAdd(gender.GenderId, gender);
            }

            return _cachedGenders.Values;
        }

        public async Task<IEnumerable<MemberStatusDTO>> GetAllMemberStatus()
        {
            if (!_cachedMemberStatus.IsEmpty)
            {
                return _cachedMemberStatus.Values;
            }

            var memberStatuses = await _systemRepo.GetAllMemberStatus();
            foreach (var memberStatus in memberStatuses)
            {
                _cachedMemberStatus.TryAdd(memberStatus.MemberStatusId, memberStatus);
            }

            return _cachedMemberStatus.Values;
        }

        public async Task<IEnumerable<LiftingLevelDTO>> GetAllLiftingLevels()
        {
            if (!_cachedLiftingLevels.IsEmpty)
            {
                return _cachedLiftingLevels.Values;
            }

            var liftingLevels = await _systemRepo.GetAllLiftingLevels();
            foreach (var liftingLevel in liftingLevels)
            {
                _cachedLiftingLevels.TryAdd(liftingLevel.LiftingLevelId, liftingLevel);
            }

            return _cachedLiftingLevels.Values;
        }
    }
}
