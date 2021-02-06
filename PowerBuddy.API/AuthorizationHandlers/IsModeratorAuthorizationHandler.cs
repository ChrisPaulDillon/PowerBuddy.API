using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PowerBuddy.API.Extensions;
using PowerBuddy.App.Services.Account;

namespace PowerBuddy.API.AuthorizationHandlers
{
    public class IsModeratorAuthorizationHandler : AuthorizationHandler<IsModeratorValidationRequirement>
    {
        private readonly IAccountService _accountService;

        public IsModeratorAuthorizationHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsModeratorValidationRequirement requirement)
        {
            var userId = context.User.FindUserId();

            if (_accountService.IsUserModerator(userId))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}