using CompanyName.ProductName.Admin.Core.Security;
using Microsoft.AspNetCore.Authorization;

namespace CompanyName.ProductName.Admin.Website.Security
{
    public sealed class ResourceAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly Permission permission;
        private readonly Resource resource;

        public ResourceAuthorizeAttribute(Permission permissionType, Resource resourceType)
        {
            permission = permissionType;
            resource = resourceType;

            SetPolicy();
        }

        public Permission PermissionType
        {
            get
            {
                return this.permission;
            }
        }

        public Resource ResourceType
        {
            get
            {
                return this.resource;
            }
        }

        private void SetPolicy() => Policy = $"Permission : {PermissionType} {ResourceType}";
    }
}
