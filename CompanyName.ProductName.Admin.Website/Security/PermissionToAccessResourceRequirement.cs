using CompanyName.ProductName.Admin.Core.Security;
using Microsoft.AspNetCore.Authorization;

namespace CompanyName.ProductName.Admin.Website.Security
{
    public class PermissionToAccessResourceRequirement : IAuthorizationRequirement
    {
        public PermissionToAccessResourceRequirement(Permission permission, Resource resource)
        {
            ResourcePermission = permission;
            SystemResource = resource;
        }

        public Permission ResourcePermission { get; private set; }

        public Resource SystemResource { get; private set; }
    }
}
