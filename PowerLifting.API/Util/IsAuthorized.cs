using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PowerLifting.API.Util
{
    public class IsAuthorized : AuthorizationHandler<IsAuthorized>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAuthorized requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "UserID"))
            {
                context.Fail();
                return null;
            }
            else
            {
                context.Succeed(requirement);
                return null;
            }
        }
    }
}