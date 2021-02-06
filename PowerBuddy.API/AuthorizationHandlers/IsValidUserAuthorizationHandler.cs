using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PowerBuddy.API.Extensions;
using PowerBuddy.App.Services.Account;

namespace PowerBuddy.API.AuthorizationHandlers
{
    public class IsValidUserAuthorizationHandler : AuthorizationHandler<IsValidUserValidationRequirement>
    {
        private readonly IAccountService _accountService;

        public IsValidUserAuthorizationHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsValidUserValidationRequirement requirement)
        {
            var userId = context.User.FindUserId();

            if (userId == null)
            {
                context.Fail();
            }

            if (await _accountService.DoesUserExist(userId))
            {
                context.Succeed(requirement);
            }

            context.Fail();
        }
    }
}