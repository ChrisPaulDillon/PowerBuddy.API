using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.System;

namespace PowerBuddy.Services.System
{
    public interface ISystemRepository
    {
        Task<IEnumerable<GenderDTO>> GetAllGenders();

        Task<IEnumerable<MemberStatusDTO>> GetAllMemberStatus();

        Task<IEnumerable<LiftingLevelDTO>> GetAllLiftingLevels();
    }
}
