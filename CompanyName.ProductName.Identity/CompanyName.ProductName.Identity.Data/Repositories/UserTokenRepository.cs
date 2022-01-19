namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class UserTokenRepository : BaseRepository, IUserTokenRepository
    {
        public UserTokenRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(UserToken entity, bool saveChanges = true)
        {
            var userToken = Mapper.Map<Entities.UserToken>(entity);
            DbContext.UserTokens.Add(userToken);
            SaveChanges(saveChanges);
        }

        public IEnumerable<UserToken> All() => DbContext.UserTokens.ProjectTo<UserToken>();

        public UserToken Find(UserTokenKey key) =>
            Mapper.Map<UserToken>(DbContext.UserTokens.FirstOrDefault(u => u.LoginProvider == key.LoginProvider
            && u.UserId == key.UserId
            && u.Name == key.Name));

        public void Remove(UserTokenKey key, bool saveChanges = true)
        {
            var userToken = DbContext.UserTokens.FirstOrDefault(u => u.LoginProvider == key.LoginProvider
            && u.UserId == key.UserId
            && u.Name == key.Name);

            if (userToken != null)
            {
                DbContext.UserTokens.Remove(userToken);
                SaveChanges(saveChanges);
            }
        }

        public void Update(UserToken entity, bool saveChanges = true)
        {
            var userToken = DbContext.UserTokens.Find(entity.UserId, entity.LoginProvider, entity.Name);
            userToken = (Entities.UserToken)Mapper.Map(entity, userToken, typeof(UserToken), typeof(Entities.UserToken));

            DbContext.UserTokens.Update(userToken);

            SaveChanges(saveChanges);
        }
    }
}
