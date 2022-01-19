namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(Role entity, bool saveChanges = true)
        {
            var roleEntity = Mapper.Map<Entities.Role>(entity);
            DbContext.Roles.Add(roleEntity);
            SaveChanges(saveChanges);
        }

        public IEnumerable<Role> All() => DbContext.Roles.ProjectTo<Role>();

        public Role Find(int key) => Mapper.Map<Role>(DbContext.Roles.FirstOrDefault(u => u.Id == key));
        
        public Role FindByName(string roleName) => Mapper.Map<Role>(DbContext.Roles.FirstOrDefault(u => u.Name == roleName));
        
        public void Remove(int key, bool saveChanges = true)
        {
            var role = DbContext.Roles.Find(key);

            if (role != null)
            {
                DbContext.Roles.Remove(role);
                SaveChanges(saveChanges);
            }
        }

        public void Update(Role entity, bool saveChanges = true)
        {
            var role = DbContext.Roles.Find(entity.Id);
            role = (Entities.Role)Mapper.Map(entity, role, typeof(Role), typeof(Entities.Role));
            
            DbContext.Roles.Update(role);

            SaveChanges(saveChanges);
        }
    }
}
