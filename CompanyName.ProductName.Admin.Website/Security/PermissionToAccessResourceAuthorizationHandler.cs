using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CompanyName.ProductName.Admin.Website.Security
{
    public class PermissionToAccessResourceAuthorizationHandler : AuthorizationHandler<PermissionToAccessResourceRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionToAccessResourceRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == GetClaimType(requirement)))
            {
                return Task.CompletedTask;
            }

            var hasAccess = Convert.ToBoolean(context.User.FindFirst(c => c.Type == GetClaimType(requirement)).Value);

            if (hasAccess)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private string GetClaimType(PermissionToAccessResourceRequirement requirement) => $"Permission : {requirement.ResourcePermission} {requirement.SystemResource}";

    }
}
