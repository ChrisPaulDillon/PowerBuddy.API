using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.System;

namespace PowerBuddy.App.Repositories.System
{
    public interface ISystemRepository
    {
        Task<IEnumerable<GenderDto>> GetAllGenders();

        Task<IEnumerable<MemberStatusDto>> GetAllMemberStatus();

        Task<IEnumerable<LiftingLevelDto>> GetAllLiftingLevels();
    }
}
