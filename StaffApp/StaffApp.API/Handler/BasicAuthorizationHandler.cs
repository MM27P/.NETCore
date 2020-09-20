using Microsoft.AspNetCore.Authorization;
using StaffApp.API.Requirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.API.Handler
{
    public class BasicAuthorizationHandler : AuthorizationHandler<CustomUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomUserRequirement requirement)
        {
            var authClaim = context.User.Identity;
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
