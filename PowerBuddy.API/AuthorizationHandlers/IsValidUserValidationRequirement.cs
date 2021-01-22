using Microsoft.AspNetCore.Authorization;

namespace PowerBuddy.API.AuthorizationHandlers
{
    public class IsValidUserValidationRequirement : IAuthorizationRequirement
    {
        public IsValidUserValidationRequirement()
        {
        }
    }
}
