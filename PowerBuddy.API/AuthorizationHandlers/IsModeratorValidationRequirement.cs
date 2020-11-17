using Microsoft.AspNetCore.Authorization;

namespace PowerBuddy.API.AuthorizationHandlers
{
    public class IsModeratorValidationRequirement : IAuthorizationRequirement
    {
        public IsModeratorValidationRequirement()
        {
        }
    }
}
