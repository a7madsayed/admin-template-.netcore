namespace CompanyName.Identity.Business.Stores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using CompanyName.Identity.Core.Models;
    using CompanyName.Identity.Core.Repositories;

    public class CustomRoleStore : IRoleStore<ApplicationRole>,
        IRoleClaimStore<ApplicationRole>, IDisposable
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IRoleClaimRepository _RoleClaimRepository;

        public CustomRoleStore(IRoleRepository roleRepository, IRoleClaimRepository roleClaimRepository)
        {
            _RoleRepository = roleRepository;
            _RoleClaimRepository = roleClaimRepository;
        }

        #region IRoleStore<IdentityRole> Members
        public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken != null)
                    cancellationToken.ThrowIfCancellationRequested();

                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                var roleEntity = getRoleEntity(role);

                _RoleRepository.Add(roleEntity);

                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
            }
        }

        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken != null)
                    cancellationToken.ThrowIfCancellationRequested();

                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                _RoleRepository.Remove(role.Id);

                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
            }
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(roleId))
                throw new ArgumentNullException(nameof(roleId));

            if (!int.TryParse(roleId, out int id))
                throw new ArgumentOutOfRangeException(nameof(roleId), $"{nameof(roleId)} is not a valid GUID");

            var roleEntity = _RoleRepository.Find(id);
            return Task.FromResult(getIdentityRole(roleEntity));
        }

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(normalizedRoleName))
                throw new ArgumentNullException(nameof(normalizedRoleName));

            var roleEntity = _RoleRepository.FindByName(normalizedRoleName);
            return Task.FromResult(getIdentityRole(roleEntity));
        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            role.NormalizedName = normalizedName;

            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            role.Name = roleName;

            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken != null)
                    cancellationToken.ThrowIfCancellationRequested();

                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                var roleEntity = getRoleEntity(role);

                _RoleRepository.Update(roleEntity);

                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = ex.Message, Description = ex.Message }));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

        #endregion

        #region IRoleClaimStore<IdentityRole> Members
        public Task<IList<Claim>> GetClaimsAsync(ApplicationRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            IList<Claim> result = _RoleClaimRepository.FindByRoleId(role.Id).Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();

            return Task.FromResult(result);
        }

        public Task AddClaimAsync(ApplicationRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            var roleClaimEntity = new RoleClaim
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                RoleId = role.Id
            };

            _RoleClaimRepository.Add(roleClaimEntity);
            
            return Task.CompletedTask;
        }

        public Task RemoveClaimAsync(ApplicationRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cancellationToken != null)
                cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            var roleClaimEntity = _RoleClaimRepository.FindByRoleId(role.Id)
                .SingleOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

            if (roleClaimEntity != null)
            {
                _RoleClaimRepository.Remove(roleClaimEntity.Id);
            }

            return Task.CompletedTask;
        }
        #endregion

        #region Private Methods
        private Role getRoleEntity(ApplicationRole value)
        {
            return value == null
                ? default(Role)
                : new Role
                {
                    ConcurrencyStamp = value.ConcurrencyStamp,
                    Id = value.Id,
                    Name = value.Name,
                    NormalizedName = value.NormalizedName
                };
        }

        private ApplicationRole getIdentityRole(Role value)
        {
            return value == null
                ? default(ApplicationRole)
                : new ApplicationRole
                {
                    ConcurrencyStamp = value.ConcurrencyStamp,
                    Id = value.Id,
                    Name = value.Name,
                    NormalizedName = value.NormalizedName
                };
        }

        #endregion
    }
}