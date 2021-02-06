using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.System;

namespace PowerBuddy.App.Repositories.System
{
    public class CachedSystemRepository : ISystemRepository
    {
        private readonly ISystemRepository _systemRepo;

        private static readonly ConcurrentDictionary<int, GenderDto> _cachedGenders = new ConcurrentDictionary<int, GenderDto>();
        private static readonly ConcurrentDictionary<int, MemberStatusDto> _cachedMemberStatus = new ConcurrentDictionary<int, MemberStatusDto>();
        private static readonly ConcurrentDictionary<int, LiftingLevelDto> _cachedLiftingLevels = new ConcurrentDictionary<int, LiftingLevelDto>();

        public CachedSystemRepository(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task<IEnumerable<GenderDto>> GetAllGenders()
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

        public async Task<IEnumerable<MemberStatusDto>> GetAllMemberStatus()
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

        public async Task<IEnumerable<LiftingLevelDto>> GetAllLiftingLevels()
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
