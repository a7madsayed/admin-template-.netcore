using System;
using System.Threading.Tasks;
using CompanyName.ProductName.Admin.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CompanyName.ProductName.Admin.Website.Security
{
    public class PermissionToAccessResourcePolicy : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider DefaultPolicyProvider { get; }

        public PermissionToAccessResourcePolicy(IOptions<AuthorizationOptions> options) => DefaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => DefaultPolicyProvider.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var subStringPolicy = policyName.Split(new char[] { ':' });

            if (subStringPolicy.Length > 1)
            {
                if (subStringPolicy[0].ToLower().Trim() == "permission")
                {
                    var subStringPremissionToResource = subStringPolicy[1].Trim().Split(' ');

                    if (subStringPremissionToResource.Length > 1)
                    {
                        var strPermissionName = subStringPremissionToResource[0];
                        var strResourceName = subStringPremissionToResource[1];
                        var parseResult = Enum.TryParse<Permission>(strPermissionName, out var permission);

                        if (parseResult)
                        {
                            parseResult = Enum.TryParse<Resource>(strResourceName, out var resource);

                            if (parseResult)
                            {
                                var policy = new AuthorizationPolicyBuilder();
                                policy.AddRequirements(new PermissionToAccessResourceRequirement(permission, resource));

                                return Task.FromResult(policy.Build());
                            }
                        }
                    }
                }
            }

            return DefaultPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
