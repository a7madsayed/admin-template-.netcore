namespace CompanyName.Identity.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Role
    {
        public Role()
        {
            RoleClaims = new HashSet<RoleClaim>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        public string Ipaddress { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
