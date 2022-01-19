namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(User entity, bool saveChanges = true)
        {
            var userEntity = Mapper.Map<Entities.User>(entity);
            DbContext.Users.Add(userEntity);
            SaveChanges(saveChanges);

            entity.Id = userEntity.Id;
        }

        public IEnumerable<User> All() => DbContext.Users.ProjectTo<User>();

        public User Find(int key) => Mapper.Map<User>(DbContext.Users.FirstOrDefault(u => u.Id == key));

        public User FindByNormalizedEmail(string normalizedEmail) => Mapper.Map<User>(DbContext.Users.FirstOrDefault(u => u.NormalizedEmail == normalizedEmail));
        
        public User FindByNormalizedUserName(string normalizedUserName) => Mapper.Map<User>(DbContext.Users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName));
        
        public void Remove(int key, bool saveChanges = true)
        {
            var user = DbContext.Users.Find(key);

            if (user != null)
            {
                DbContext.Users.Remove(user);
                SaveChanges(saveChanges);
            }
        }

        public void Update(User entity, bool saveChanges = true)
        {
            var user = DbContext.Users.Find(entity.Id);
            user = (Entities.User)Mapper.Map(entity, user, typeof(User), typeof(Entities.User));
            DbContext.Users.Update(user);

            SaveChanges(saveChanges);
        }
    }
}
