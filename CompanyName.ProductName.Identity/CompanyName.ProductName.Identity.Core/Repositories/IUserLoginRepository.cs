namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IUserLoginRepository
    {
        void Add(UserLogin entity, bool saveChanges = true);

        IEnumerable<UserLogin> All();

        UserLogin Find(UserLoginKey id);

        IEnumerable<UserLogin> FindByUserId(int userId);

        void Remove(UserLoginKey key, bool saveChanges = true);

        void Update(UserLogin entity, bool saveChanges = true);
    }
}
