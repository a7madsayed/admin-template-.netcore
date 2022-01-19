namespace CompanyName.Identity.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        public UserRoleRepository(IdentityDbContext dbContext) : base(dbContext) { }

        public void Add(int userId, string roleName, bool saveChanges = true)
        {
            var roleId = DbContext.Roles.FirstOrDefault(r => r.Name == roleName)?.Id;

            if (roleId.HasValue)
            {
                var userRole = new Entities.UserRole
                {
                    RoleId = roleId.Value,
                    UserId = userId
                };

                DbContext.UserRoles.Add(userRole);
                SaveChanges(saveChanges);
            }
        }

        public IEnumerable<string> GetRoleNamesByUserId(int userId) => DbContext.Users.FirstOrDefault(u => u.Id == userId).UserRoles.Select(u => u.Role.Name);

        public IEnumerable<User> GetUsersByRoleName(string roleName) => Mapper.Map<IEnumerable<User>>(DbContext.Roles.FirstOrDefault(r => r.NormalizedName == roleName).UserRoles.Select(r => r.User));

        public void Remove(int userId, string roleName, bool saveChanges = true)
        {
            var userRoles = DbContext.UserRoles.Where(ur => ur.UserId == userId && ur.Role.NormalizedName == roleName);
            DbContext.UserRoles.RemoveRange(userRoles);
            SaveChanges(saveChanges);
        }
    }
}
