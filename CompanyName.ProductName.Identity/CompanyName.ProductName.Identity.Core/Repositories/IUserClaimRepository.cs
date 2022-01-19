namespace CompanyName.Identity.Core.Repositories
{
    using System.Collections.Generic;
    using CompanyName.Identity.Core.Models;

    public interface IUserClaimRepository
    {
        void Add(UserClaim entity, bool saveChanges = true);

        IEnumerable<UserClaim> All();

        UserClaim Find(int key);

        IEnumerable<UserClaim> GetByUserId(int userId);

        IEnumerable<UserClaim> GetAllByUserId(int userId);

        IEnumerable<User> GetUsersForClaim(string claimType, string claimValue);

        void Remove(int key, bool saveChanges = true);

        void Update(UserClaim entity, bool saveChanges = true);

        int SaveChanges();
    }
}
