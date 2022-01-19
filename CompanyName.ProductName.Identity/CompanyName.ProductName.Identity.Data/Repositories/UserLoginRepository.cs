namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class UserLoginRepository : BaseRepository, IUserLoginRepository
    {
        public UserLoginRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(UserLogin entity, bool saveChanges = true)
        {
            var userLogin = Mapper.Map<Entities.UserLogin>(entity);
            DbContext.UserLogins.Add(userLogin);
            SaveChanges(saveChanges);
        }

        public IEnumerable<UserLogin> All() => DbContext.UserLogins.ProjectTo<UserLogin>();

        public UserLogin Find(UserLoginKey id) => Mapper.Map<UserLogin>(DbContext.UserLogins.FirstOrDefault(u => u.LoginProvider == id.LoginProvider && u.ProviderKey == id.ProviderKey));

        public IEnumerable<UserLogin> FindByUserId(int userId) => DbContext.UserLogins.Where(u => u.UserId == userId).ProjectTo<UserLogin>();

        public void Remove(UserLoginKey key, bool saveChanges = true)
        {
            var userLogin = DbContext.UserLogins.FirstOrDefault(u => u.LoginProvider == key.LoginProvider && u.ProviderKey == key.ProviderKey);

            if (userLogin != null)
            {
                DbContext.UserLogins.Remove(userLogin);
                SaveChanges(saveChanges);
            }
        }

        public void Update(UserLogin entity, bool saveChanges = true)
        {
            var userLogin = DbContext.UserLogins.Find(entity.LoginProvider, entity.ProviderKey);
            userLogin = (Entities.UserLogin)Mapper.Map(entity, userLogin, typeof(UserLogin), typeof(Entities.UserLogin));

            DbContext.UserLogins.Update(userLogin);

            SaveChanges(saveChanges);
        }
    }
}
