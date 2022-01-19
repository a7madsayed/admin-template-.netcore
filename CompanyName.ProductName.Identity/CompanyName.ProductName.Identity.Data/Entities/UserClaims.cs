namespace CompanyName.Identity.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class UserClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(100)]
        public string ClaimType { get; set; }

        [MaxLength(256)]
        public string ClaimValue { get; set; }

        public User User { get; set; }
    }
}
