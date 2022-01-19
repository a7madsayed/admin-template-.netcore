namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IRoleRepository
    {
        void Add(Role entity, bool saveChanges = true);

        IEnumerable<Role> All();

        Role Find(int key);

        Role FindByName(string roleName);

        void Remove(int key, bool saveChanges = true);

        void Update(Role entity, bool saveChanges = true);
    }
}
