namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IRoleClaimRepository
    {
        void Add(RoleClaim entity, bool saveChanges = true);

        RoleClaim Find(int key);

        IEnumerable<RoleClaim> FindByRoleId(int roleId);

        IEnumerable<RoleClaim> All();

        void Remove(int key, bool saveChanges = true);

        void Update(RoleClaim entity, bool saveChanges = true);
    }
}
