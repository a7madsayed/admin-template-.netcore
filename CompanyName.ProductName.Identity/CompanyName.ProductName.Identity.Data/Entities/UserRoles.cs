namespace CompanyName.Identity.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserRole
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public User User { get; set; }
    }
}
