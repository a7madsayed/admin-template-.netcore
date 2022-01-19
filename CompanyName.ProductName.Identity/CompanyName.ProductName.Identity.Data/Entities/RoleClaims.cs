namespace CompanyName.Identity.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class RoleClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; }

        [MaxLength(100)]
        public string ClaimType { get; set; }

        [MaxLength(256)]
        public string ClaimValue { get; set; }

        public Role Role { get; set; }
    }
}
