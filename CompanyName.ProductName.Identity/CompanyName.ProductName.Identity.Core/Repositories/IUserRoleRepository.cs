namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IUserRoleRepository
    {
        void Add(int userId, string roleName, bool saveChanges = true);

        IEnumerable<string> GetRoleNamesByUserId(int userId);

        IEnumerable<User> GetUsersByRoleName(string roleName);

        void Remove(int userId, string roleName, bool saveChanges = true);
    }
}
