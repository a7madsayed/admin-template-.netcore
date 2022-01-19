namespace CompanyName.Identity.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserLogin
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(450)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(450)]
        public string ProviderKey { get; set; }

        [MaxLength(100)]
        public string ProviderDisplayName { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
