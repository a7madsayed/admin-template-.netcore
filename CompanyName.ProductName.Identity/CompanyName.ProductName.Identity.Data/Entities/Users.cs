namespace CompanyName.Identity.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public User()
        {
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string UserName { get; set; }

        [MaxLength(256)]
        public string NormalizedUserName { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string NormalizedEmail { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        [Required]
        public bool LockoutEnabled { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public ICollection<UserClaim> UserClaims { get; set; }

        public ICollection<UserLogin> UserLogins { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<UserToken> UserTokens { get; set; }
    }
}
