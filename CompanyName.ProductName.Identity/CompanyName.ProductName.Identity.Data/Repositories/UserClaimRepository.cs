namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class UserClaimRepository : BaseRepository, IUserClaimRepository
    {
        public UserClaimRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(UserClaim entity, bool saveChanges = true)
        {
            var userClaim = Mapper.Map<Entities.UserClaim>(entity);
            DbContext.UserClaims.Add(userClaim);
            SaveChanges(saveChanges);
        }

        public IEnumerable<UserClaim> All() => DbContext.UserClaims.ProjectTo<UserClaim>();

        public UserClaim Find(int key) => Mapper.Map<UserClaim>(DbContext.UserClaims.FirstOrDefault(u => u.Id == key));

        public IEnumerable<UserClaim> GetByUserId(int userId) => DbContext.UserClaims.Where(uc => uc.UserId == userId).ProjectTo<UserClaim>();

        public IEnumerable<UserClaim> GetAllByUserId(int userId)
        {
            var userClaims = DbContext.UserClaims.Where(uc => uc.UserId == userId).ProjectTo<UserClaim>().ToList();
            var roleClaims = ( from u in DbContext.UserRoles
                               join r in DbContext.Roles on u.RoleId equals r.Id
                               join rc in DbContext.RoleClaims on r.Id equals rc.RoleId
                               select new UserClaim
                               {
                                   ClaimType = rc.ClaimType,
                                   ClaimValue = rc.ClaimValue
                               } ).Distinct();
            
            userClaims.AddRange(roleClaims);

            return userClaims;
        }

        public IEnumerable<User> GetUsersForClaim(string claimType, string claimValue) => DbContext.Users.Where(u => u.UserClaims.Any(c => c.ClaimType == claimType && c.ClaimValue == claimValue)).ProjectTo<User>();

        public void Remove(int key, bool saveChanges = true)
        {
            var userClaim = DbContext.UserClaims.Find(key);

            if (userClaim != null)
            {
                DbContext.UserClaims.Remove(userClaim);
                SaveChanges(saveChanges);
            }
        }

        public int SaveChanges() => SaveChanges();

        public void Update(UserClaim entity, bool saveChanges = true)
        {
            var userClaim = DbContext.UserClaims.Find(entity.Id);
            userClaim = (Entities.UserClaim)Mapper.Map(entity, userClaim, typeof(UserClaim), typeof(Entities.UserClaim));

            DbContext.UserClaims.Update(userClaim);

            SaveChanges(saveChanges);
        }
    }
}
