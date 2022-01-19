namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IUserTokenRepository
    {
        void Add(UserToken entity, bool saveChanges = true);

        IEnumerable<UserToken> All();

        UserToken Find(UserTokenKey key);

        void Remove(UserTokenKey key, bool saveChanges = true);

        void Update(UserToken entity, bool saveChanges = true);
    }
}
