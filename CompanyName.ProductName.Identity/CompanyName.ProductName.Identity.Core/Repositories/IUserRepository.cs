namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IUserRepository
    {
        void Add(User entity, bool saveChanges = true);

        IEnumerable<User> All();

        User Find(int key);

        User FindByNormalizedUserName(string normalizedUserName);

        User FindByNormalizedEmail(string normalizedEmail);

        void Remove(int key, bool saveChanges = true);

        void Update(User entity, bool saveChanges = true);
    }
}
