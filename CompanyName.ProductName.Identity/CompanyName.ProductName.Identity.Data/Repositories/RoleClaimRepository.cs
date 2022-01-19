namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class RoleClaimRepository : BaseRepository, IRoleClaimRepository
    {
        public RoleClaimRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(RoleClaim entity, bool saveChanges = true)
        {
            var roleClaimEntity = Mapper.Map<Entities.RoleClaim>(entity);
            DbContext.RoleClaims.Add(roleClaimEntity);
            SaveChanges(saveChanges);
        }

        public RoleClaim Find(int key) => Mapper.Map<RoleClaim>(DbContext.RoleClaims.FirstOrDefault(u => u.Id == key));

        public IEnumerable<RoleClaim> FindByRoleId(int roleId) => DbContext.RoleClaims.Where(u => u.RoleId == roleId).ProjectTo<RoleClaim>();

        public IEnumerable<RoleClaim> All() => DbContext.RoleClaims.ProjectTo<RoleClaim>();
        
        public void Remove(int key, bool saveChanges = true)
        {
            var roleClaim = DbContext.RoleClaims.Find(key);

            if (roleClaim != null)
            {
                DbContext.RoleClaims.Remove(roleClaim);
                SaveChanges(saveChanges);
            }
        }

        public void Update(RoleClaim entity, bool saveChanges = true)
        {
            var roleClaim = DbContext.RoleClaims.Find(entity.Id);
            roleClaim = (Entities.RoleClaim)Mapper.Map(entity, roleClaim, typeof(RoleClaim), typeof(Entities.RoleClaim));

            DbContext.RoleClaims.Update(roleClaim);

            SaveChanges(saveChanges);
        }
    }
}
